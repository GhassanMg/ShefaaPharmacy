using DataLayer.Enums;
using DataLayer.Helper;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Helper
{
    public class Auth
    {
        public static bool IsAdmin()
        {
            try
            {
                int position = Convert.ToInt32(UserLoggedIn.User.Position);
                if (position > Convert.ToInt32(Position.admin))
                {
                    return false;
                }
                if (RDSFECXA__WEWDSA.Ree())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        public static bool IsManager()
        {
            try
            {
                int position = Convert.ToInt32(UserLoggedIn.User.Position);
                if (position > Convert.ToInt32(Position.manager))
                {
                    return false;
                }
                return RDSFECXA__WEWDSA.Ree();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool DataEntryAndDown()
        {
            try
            {
                int position = Convert.ToInt32(UserLoggedIn.User.Position);
                if (position >= Convert.ToInt32(Position.dataEntry))
                {
                    if (RDSFECXA__WEWDSA.Ree())
                    {
                        
                        return true;
                    }
                    else
                    {
                        _MessageBoxDialog.Show("النسخة غير مسجلة", MessageBoxState.Error);
                        return false;
                    }
                }
                else
                {
                    
                    return false;
                }

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        public static bool IsDataEntry()
        {
            try
            {
                int position = Convert.ToInt32(UserLoggedIn.User.Position);
                if (position > Convert.ToInt32(Position.dataEntry))
                {
                    return false;
                }
                else
                {
                    if (RDSFECXA__WEWDSA.Ree())
                    {
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        public static bool IsReportReader()
        {
            try
            {
                int position = Convert.ToInt32(UserLoggedIn.User.Position);
                if (position > Convert.ToInt32(Position.reportReader))
                {
                    return false;
                }
                if (RDSFECXA__WEWDSA.Ree())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
