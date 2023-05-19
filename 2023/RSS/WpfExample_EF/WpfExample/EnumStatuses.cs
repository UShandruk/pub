using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample
{
    /// <summary>
    /// Статусы товаров
    /// </summary>
    public enum EnumStatuses
    {
        /// <summary>
        /// Принят
        /// </summary>
        Taken = 1,

        /// <summary>
        /// На складе
        /// </summary>
        InWarehouse = 2,

        /// <summary>
        /// Продано
        /// </summary>
        SoldOut = 3
    }
}