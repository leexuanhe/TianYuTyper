﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TyModel.Model;

namespace TyModel.Data
{
    public class  TypeAchieveInfo
    {
        /// <summary>
        /// 数据
        /// </summary>
        public TypeType TypeData { set; get; }
        /// <summary>
        ///     说明
        /// </summary>
        public string TypeInfo { set; get; }
    }
    public class TypeAchievementConfig
    {
        private TypeType _speed = new TypeType { 描述词 = "速度", 优先级 = 1, 值类型 = 值类型.双精度 };
        private TypeType _jj = new TypeType { 描述词 = "击键", 优先级 = 2, 值类型 = 值类型.双精度 };
        private TypeType _mc = new TypeType { 描述词 = "码长", 优先级 = 3, 值类型 = 值类型.双精度 };
        private TypeType _hg = new TypeType { 描述词 = "回改", 优先级 = 4, 值类型 = 值类型.整型 };
        private TypeType _cz = new TypeType { 描述词 = "错字", 优先级 = 5, 值类型 = 值类型.整型 };
        private TypeType _js = new TypeType { 描述词 = "键数", 优先级 = 6, 值类型 = 值类型.整型 };
        private TypeType _zs = new TypeType { 描述词 = "字数", 优先级 = 7, 值类型 = 值类型.整型 };
        private TypeType _maxStay = new TypeType {描述词 = "停留", 优先级 = 8, 值类型 = 值类型.字符串, 显示描述词 = false};
        private TypeType _typeWords = new TypeType { 描述词 = "打词", 优先级 = 9, 值类型 = 值类型.字符串,连接值 = ""};
        private TypeType _backTimesMax = new TypeType { 描述词 = "回次", 优先级 = 10, 值类型 = 值类型.字符串,显示描述词 = false,为空不显示 = true};

        private TypeType _input = new TypeType
            {
                描述词 = "输入法",
                关连值 = "五笔",
                连接值 = "：",
                值类型 = 值类型.字符串,
                优先级 = 999,
                为空不显示 = true
            };

        private TypeType _startSpeed = new TypeType
        {
            描述词 = "起步",
            连接值 = "",
            值类型 = 值类型.字符串,
            优先级 = 11,
            为空不显示 = true
        };

        public TypeType Speed { set { _speed = value; } get { return _speed; } }
        public TypeType Jj { set { _jj = value; } get { return _jj; } }
        public TypeType Mc { set { _mc = value; } get { return _mc; } }
        public TypeType Hg { set { _hg = value; } get { return _hg; } }
        public TypeType Cz { set { _cz = value; } get { return _cz; } }
        public TypeType Js { set { _js = value; } get { return _js; } }
        public TypeType Zs { set { _zs = value; } get { return _zs; } }
        public TypeType MaxStay { set { _maxStay = value; } get { return _maxStay; } }
        public TypeType TypeWords { set { _typeWords = value; } get { return _typeWords; } }
        public TypeType StartSpeed
        {
            set { _startSpeed = value; }
            get { return _startSpeed; }
        }

        /// <summary>
        /// 回改次数最高
        /// </summary>
        public TypeType BackTimesMax
        {
            set { _backTimesMax = value; }
            get { return _backTimesMax; }
        }
        /// <summary>
        /// 输入法
        /// </summary>
        public TypeType Input
        {
            set { _input = value; }
            get { return _input; }
        }
    }
    /// <summary>
    /// 跟打成绩 / 用于排序显示
    /// </summary>
    public class TypeAchievement
    {
        public Dictionary<string,TypeAchieveInfo> AchievementDic = new Dictionary<string, TypeAchieveInfo>(); 
        public double Speed2 = 0;
       
        public TypeAchievement()
        {
            Init();
        }

        public void Init()
        {
            ReAdd();
            ReSort();
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        public void ReAdd()
        {
            AchievementDic.Clear();
            AchievementDic.Add("速度", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Speed, TypeInfo = "速度显示 单位为 字每分" });
            AchievementDic.Add("击键", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Jj, TypeInfo = "击键显示 单位为 键每秒" });
            AchievementDic.Add("码长", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Mc, TypeInfo = "码长显示 单位为 键每字" });
            AchievementDic.Add("回改", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Hg, TypeInfo = "回改次数 而非按backspace次数" });
            AchievementDic.Add("错字", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Cz, TypeInfo = "错字个数" });
            AchievementDic.Add("键数", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Js, TypeInfo = "按键总次数" });
            AchievementDic.Add("字数", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Zs, TypeInfo = "跟打字数显示" });
            AchievementDic.Add("停留", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.MaxStay, TypeInfo = "[字或词]时间" });
            AchievementDic.Add("打词", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.TypeWords, TypeInfo = "打词【次数】(打词长度占比/打词击键)" });
            AchievementDic.Add("回次", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.BackTimesMax, TypeInfo = "回改最高次数的字及次数显示" });
            AchievementDic.Add("输入法", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.Input, TypeInfo = "输入法是由程序自动获取的，无法自由设置" });
            AchievementDic.Add("起步", new TypeAchieveInfo { TypeData = GlobalModel.Instance.Config.TypeAchievementConfig.StartSpeed, TypeInfo = "用户跟打前五次输入产生的 速度/击键/码长 为起步数据" });
        }
        /// <summary>
        /// 重新排序
        /// </summary>
        public void ReSort()
        {
            AchievementDic = AchievementDic.OrderBy(o => o.Value.TypeData.优先级).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// 输入法前处理
        /// </summary>
        public void InputOperation()
        {
            //能否被空格分隔
            var temp = TypeData.Instance.GetTypeAchievement().AchievementDic["输入法"];
            var test1 = temp.TypeData.关连值.ToString().Split(' ');
            var reg1 = new Regex(@"五笔|拼音|输入法");
            if (test1.Length > 0)
            {
                for (var i = test1.Length - 1; i >= 0; i--)
                {
                    if (!reg1.IsMatch(test1[i])) continue;
                    temp.TypeData.关连值 = test1[i].Trim().Replace("输入法","");
                    break;
                }
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            foreach (var typeType in AchievementDic)
            {
                switch (typeType.Value.TypeData.值类型)
                {
                    case 值类型.字符串:
                        typeType.Value.TypeData.关连值 = "";
                        break;
                    default:
                        typeType.Value.TypeData.关连值 = 0;
                        break;
                }
            }
        }

        /// <summary>
        /// 恢复默认配置
        /// </summary>
        public void ReSet()
        {
            GlobalModel.Instance.Config.TypeAchievementConfig = new TypeAchievementConfig();
            ReAdd();
            ReSort();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            //段号
            str.Append(TypeData.Instance.TypeInfo.DuanHao + GlobalModel.Instance.Config.SplitString);
            // 根据优先级来确定谁先输出
            //Achievement.OrderBy(o => o.优先级);
            foreach (var typeType in AchievementDic.Where(typeType => typeType.Value.TypeData.显示))
            {
                if (typeType.Value.ToString().Length > 0)
                    str.Append(typeType.Value.TypeData + GlobalModel.Instance.Config.SplitString);
            }
            //签名
            if (!string.IsNullOrEmpty(GlobalModel.Instance.Config.UserSignWrite))
            {
                str.Append("个签：" + GlobalModel.Instance.Config.UserSignWrite.Trim() + GlobalModel.Instance.Config.SplitString);
            }
            //版本号
            str.Append(GlobalModel.Instance.FormInfo.LittleVersion);
            return str.ToString();
        }
    }

    public class TypeType
    {
        private bool _显示 = true;
        private bool _显示描述词 = true;
        public int 优先级 { set; get; }
        public string 描述词 { set; get; }
        public object 关连值 { set; get; }
        public string 连接值 = "：";
        private bool _为空不显示 = false;
        public 值类型 值类型 { set; get; }
        public bool 为空不显示
        {
            set { _为空不显示 = value; }
            get { return _为空不显示; }
        }

        public bool 显示
        {
            set { _显示 = value; }
            get { return _显示; }
        }
        public bool 显示描述词
        {
            set { _显示描述词 = value; }
            get { return _显示描述词; }
        }

        public override string ToString()
        {
            var val = 关连值;
            var conn = (连接值.Length > 0) ? 连接值 : "";
            var desc = (显示描述词 ? 描述词 : "");
            switch (值类型)
            {
                case 值类型.双精度:
                    val = ((double)关连值).ToString("0.00");
                    if (描述词 == "速度" && TypeData.Instance.ErrorWords.Count > 0)
                        val += "/" + TypeData.Instance.GetTypeAchievement().Speed2.ToString("0.00");
                    break;
                case 值类型.字符串:
                    if (显示描述词)
                        desc += conn;
                    break;

            }
            var re = (关连值.ToString() == "0" && 关连值.ToString() == "" && 为空不显示) ? "" : desc + val;
            return re.Trim();
        }
    }

    public enum 值类型
    {
        整型,
        双精度,
        字符串
    }
}
