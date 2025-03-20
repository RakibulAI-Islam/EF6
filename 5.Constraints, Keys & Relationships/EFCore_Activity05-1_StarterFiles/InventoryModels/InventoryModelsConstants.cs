using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class InventoryModelsConstants
    {
        /*String Length Constants.*/
        public const int MAX_DESCRIPTION_LENGTH = 250;
        public const int MAX_NAME_LENGTH = 100;
        public const int MAX_NOTES_LENGTH = 2000;
        public const int MAX_USERID_LENGTH = 50;
        /*Range on Numeric fields Constants.*/
        public const int MINIMUM_QUANTITY = 0;
        public const int MAXIMUM_QUANTITY = 1000;
        public const double MINIMUM_PRICE = 0.0;
        public const double MAXIMUM_PRICE = 25000.0;
        /*Max_Length of ColorValue & ColorName.*/
        public const int MAX_COLORVALUE_LENGTH = 25;
        public const int MAX_COLORNAME_LENGTH = 25;
        /*Max_Length of PlayerName & Player Description.*/
        public const int MAX_PLAYERNAME_LENGTH = 50;
        public const int MAX_PLAYERDESCRIPTION_LENGTH = 500;

    }
}
