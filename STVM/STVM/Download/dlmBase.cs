using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STVM;
using STVM.Data;

namespace STVM.Download
{
    abstract class dlmBase
    {
        protected List<tDownload> internalDownloads;

        public string DestinationPath { get; set; }
        public int MaximumConnections { get; set; }
        public bool SendTelecastLink { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address { get; set; }
        public virtual bool UseHttps { get; set; }

        public DownloadMethods Method { get; protected set; }
        public bool CanCancel { get; protected set; }
        public bool NeedCredentials { get; protected set; }

        public abstract string Name { get; }

        public dlmBase()
        {
            internalDownloads = new List<tDownload>();
            CanCancel = false;
            NeedCredentials = false;
            SendTelecastLink = false;
        }

        public virtual bool Login()
        {
            return true;
        }

        public virtual void Logout()
        { }

        public virtual void Add(tDownload Download)
        {
            AddRange(new[] { Download });
        }

        public abstract void AddRange(IEnumerable<tDownload> Downloads);

        public virtual void Restore(tDownload Download)
        {
            RestoreRange(new[] { Download });
        }

        public abstract void RestoreRange(IEnumerable<tDownload> Downloads);

        public virtual void Cancel(tDownload Download)
        { }

        public virtual void CancelRange(IEnumerable<tDownload> Downloads)
        {
            foreach (tDownload Download in Downloads) { Cancel(Download); }
        }

        public virtual void Clear()
        { }

        public virtual bool CanClose()
        {
            return true;
        }
    }
}
