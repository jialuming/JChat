using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEntity.Enum.SysFriendEnum
{
    public enum NameDisplayMode
    {
        /// <summary>
        /// 昵称
        /// </summary>
        NickName,
        /// <summary>
        /// 备注
        /// </summary>
        Remarks,
        /// <summary>
        /// 昵称和备注
        /// </summary>
        NameAndNickName
    }

    public enum DisplayMode
    {
        /// <summary>
        /// 单列显示
        /// </summary>
        SingleColumnDisplay,
        /// <summary>
        /// 多列显示
        /// </summary>
        MultipleColumnsDisplay,
    }
}
