using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Elements
{
    public class UserProfiler:IUserProfiler
    {
        public event Action IWasBorn;
        private int typeId;
        public int TypeId
        {
            get { return typeId; }
        }
        private int id;
        public int Id
        {
            get { return id; }
        }

        public UserProfiler(int typeId, int id)
        {
            this.typeId = typeId;
            this.id = id;
            IWasBorn?.Invoke();
        }
    }
}
