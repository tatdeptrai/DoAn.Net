using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnMonHoc_MultipleChoiceApp
{
    internal class pair
    {
        private int key;
        private string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }

        public pair(int k, string v) {
            this.key = k;
            this.value = v;
        }

    }
}
