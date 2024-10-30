using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDo.Shared.Services   
{
    public interface IPhotoManager 
    {
        public Task<string> TakePhotoAsync();
        public Task<string> PickPhotoAsync();
   
    }
}
