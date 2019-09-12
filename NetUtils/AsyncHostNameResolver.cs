
/*
 * 
 * 
 * contact: hjohneny99@gmail.com
 * 
 * 
 *  - The names of contributors may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *
 */
 

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace NetUtils
{
	class AsyncHostNameResolver
	{

		private delegate IPHostEntry GetHostEntryDelegate(string addr);

		private IPHostEntry GetHostEntry(string addr)
		{
			try { return Dns.GetHostEntry(addr); }
			catch { return null; }
		}

		private class AsyncStateUni
		{
			public GetHostEntryDelegate _resolveMethod;
			public AsyncStateUni(GetHostEntryDelegate resolveMethod) { _resolveMethod = resolveMethod; }
		}

		#region ResolveHostName

		public delegate void StoreHostNameDelegate(string hostName);

		private class AsyncStateForName : AsyncStateUni
		{
			public StoreHostNameDelegate _storeResultMethod;
			public AsyncStateForName(GetHostEntryDelegate resolveMethod, StoreHostNameDelegate storeResultMethod) : base(resolveMethod) { _storeResultMethod = storeResultMethod; }
		}

		public void ResolveHostName(IPAddress address, StoreHostNameDelegate callback)
		{
			AsyncStateForName state = new AsyncStateForName(new GetHostEntryDelegate(GetHostEntry), callback);
			state._resolveMethod.BeginInvoke(address.ToString(), new AsyncCallback(HostNameResolved), state);
		}

		private void HostNameResolved(IAsyncResult result)
		{
			try
			{
				AsyncStateForName state = (AsyncStateForName)result.AsyncState;
				IPHostEntry entry = state._resolveMethod.EndInvoke(result);
				if (entry != null)
					state._storeResultMethod(entry.HostName);
			}
			catch { }
		}

		#endregion

		#region ResolveHostIP

		public delegate void StoreHostIPDelegate(IPAddress[] addreses);

		private class AsyncStateForIP : AsyncStateUni
		{
			public StoreHostIPDelegate _storeResultMethod;
			public AsyncStateForIP(GetHostEntryDelegate resolveMethod, StoreHostIPDelegate storeResultMethod) : base(resolveMethod) { _storeResultMethod = storeResultMethod; }
		}

		public void ResolveHostIP(string name, StoreHostIPDelegate callback)
		{
			AsyncStateForIP state = new AsyncStateForIP(new GetHostEntryDelegate(GetHostEntry), callback);
			state._resolveMethod.BeginInvoke(name, new AsyncCallback(HostIPResolved), state);
		}

		private void HostIPResolved(IAsyncResult result)
		{
			try
			{
				AsyncStateForIP state = (AsyncStateForIP)result.AsyncState;
				IPHostEntry entry = state._resolveMethod.EndInvoke(result);
				if(entry != null)
					state._storeResultMethod(entry.AddressList);
			}
			catch { }
		}

		#endregion

	}
}
