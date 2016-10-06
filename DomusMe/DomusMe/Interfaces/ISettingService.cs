using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomusMe.Interfaces
{
    public interface ISettingService
    {
        void AddOrUpdateSetting<T>(string key, T val);
        T GetSetting<T>(string key, T defaultValue = default(T));
    }
}
