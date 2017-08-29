using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace NativeTest.Common
{
    public class AppContainer
    {
        public UnityContainer container { get; set; }

        public AppContainer()
        {
            this.container = new UnityContainer();
            this.Register();
        }

        private void Register()
        {
            this.container.regis
        }
    }
}
