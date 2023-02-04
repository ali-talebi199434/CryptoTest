using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Crypto;

namespace ViewModel.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Market> Markets{ get; set; } = new List<Market>();
    }
}
