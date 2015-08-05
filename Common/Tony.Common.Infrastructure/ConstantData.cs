using System.Collections.ObjectModel;

namespace Tony.Common.Infrastructure
{
    public static class ConstantData
    {

        public const string PARAM_SUITE_ID = "PARAM_SUITE_ID";
        public const string PARAM_DISH_CATEGORY_ID = "PARAM_DISH_CATEGORY_ID";
        public const string PARAM_DEPARTMENT_ID = "PARAM_DEPARTMENT_ID";

        #region ui ass
        public static ObservableCollection<string> GetHours()
        {
            return new ObservableCollection<string> { "00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11",
            "12","13", "14","15", "16", "17", "18", "19", "20", "21", "22", "23"};
        }

        public static ObservableCollection<string> GetMunites()
        {
            return new ObservableCollection<string> { "00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11",
            "12","13", "14","15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
            "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48",
            "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"};
        }

        public const string ALL = "ALL";

        public const string NAME = "NAME";

        public const string PHONE = "PHONE NO";

        public const string TAGNO = "TAG NO";

        public const string AROUND = "AROUND";

        public const string GONE = "GONE";
        #endregion

        #region netcom

        #region settings

        #region profile
        public const string SAVE_PROFILE_REQUEST = "SAVE_PROFILE_REQUEST";
        public const string SAVE_PROFILE_REPLY = "SAVE_PROFILE_REPLY";
        
        public const string GET_PROFILE_REQUEST = "GET_PROFILE_REQUEST";
        public const string GET_PROFILE_REPLY = "GET_PROFILE_REPLY";
        #endregion

        #region suite
        public const string ADD_SUITE_REQUEST = "ADD_SUITE_REQUEST";
        public const string ADD_SUITE_REPLY = "ADD_SUITE_REPLY";

        public const string GET_SUITE_REQUEST = "GET_SUITE_REQUEST";
        public const string GET_SUITE_REPLY = "GET_SUITE_REPLY";


        public const string ADD_ROOM_REPLY = "ADD_ROOM_REPLY";
        public const string ADD_ROOM_REQUEST = "ADD_ROOM_REQUEST";

        public const string GET_ROOM_REQUEST = "GET_ROOM_REQUEST";
        public const string GET_ROOM_REPLY = "GET_ROOM_REPLY";
        #endregion

        #region invetory
        public const string SAVE_INVENTORY_REQUEST = "THE_SAVE_INVENTORY_REQUEST";
        public const string SAVE_INVENTORY_REPLY = "THE_SAVE_INVENTORY_REPLY";

        public const string DELETE_INVENTORY_REQUEST = "DELETE_INVENTORY_REQUEST";
        public const string DELETE_INVENTORY_REPLY = "DELETE_INVENTORY_REPLY";

        public const string GET_INVENTORIES_REQUEST = "GET_INVENTORIES_REQUEST";
        public const string GET_INVENTORIES_REPLY = "GET_INVENTORIES_REPLY";
        #endregion

        #region dishes
        public const string SAVE_DISH_CATEGORY_REQUEST = "SAVE_DISH_CATEGORY_REQUEST";
        public const string SAVE_DISH_CATEGORY_REPLY = "SAVE_DISH_CATEGORY_REPLY";

        public const string DELETE_DISH_CATEGORY_REQUEST = "DELETE_DISH_CATEGORY_REQUEST";
        public const string DELETE_DISH_CATEGORY_REPLY = "DELETE_DISH_CATEGORY_REPLY";

        public const string GET_DISH_CATEGORY_REQUEST = "GET_DISH_CATEGORY_REQUEST";
        public const string GET_DISH_CATEGORY_REPLY = "GET_DISH_CATEGORY_REPLY";


        public const string SAVE_DISH_REQUEST = "SAVE_DISH_REQUEST";
        public const string SAVE_DISH_REPLY = "SAVE_DISH_REPLY";

        public const string DELETE_DISH_REQUEST = "DELETE_DISH_REQUEST";
        public const string DELETE_DISH_REPLY = "DELETE_DISH_REPLY";

        public const string GET_DISH_REQUEST = "GET_DISH_REQUEST";
        public const string GET_DISH_REPLY = "GET_DISH_REPLY";
        #endregion

        #region staff
        public const string SAVE_DEPARTMENT_REQUEST = "T_SAVE_DEPT_REQUEST";
        public const string SAVE_DEPARTMENT_REPLY = "T_SAVE_DEPT_REPLY";

        public const string DELETE_DEPARTMENT_REQUEST = "THE_DELETE_DEPARTMENT_REQUEST";
        public const string DELETE_DEPARTMENT_REPLY = "THE_DELETE_DEPARTMENT_REPLY";

        public const string GET_DEPARTMENT_REQUEST = "THE_GET_DEPARTMENT_REQUEST";
        public const string GET_DEPARTMENT_REPLY = "THE_GET_DEPARTMENT_REPLY";


        public const string SAVE_STAFF_REQUEST = "THE_SAVE_STAFF_REQUEST";
        public const string SAVE_STAFF_REPLY = "THE_SAVE_STAFF_REPLY";

        public const string DELETE_STAFF_REQUEST = "THE_DELETE_STAFF_REQUEST";
        public const string DELETE_STAFF_REPLY = "THE_DELETE_STAFF_REPLY";

        public const string GET_STAFF_REQUEST = "THE_GET_STAFF_REQUEST";
        public const string GET_STAFF_REPLY = "THE_GET_STAFF_REPLY";


        #endregion

        #endregion




        #endregion

    }
}
