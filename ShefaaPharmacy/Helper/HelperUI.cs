using DataLayer.Enums;
using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace ShefaaPharmacy.Helper
{
    public static class HelperUI
    {
        public class MyBindingList<T> : BindingList<T>
        {
            public T Find(Predicate<T> predicate)
            {
                if (predicate == null) throw new ArgumentNullException("predicate");
                foreach (T item in this)
                {
                    if (predicate(item)) return item;
                }
                return default(T);
            }
        }
        public static bool IsAdministrator =>
                            new WindowsPrincipal(WindowsIdentity.GetCurrent())
                                .IsInRole(WindowsBuiltInRole.Administrator);
        public static void ExecuteCommandAsAdmin(string command)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            var collection = command.Split('@');
            foreach (var item in collection)
            {
                cmd.StandardInput.WriteLine(item);
            }
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }
        public static ColumnShowState HiddenColumnGrid<T>() where T : class
        {
            ColumnShowState columnShowState = new ColumnShowState();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs.Length > 0)
                {
                    foreach (object attr in attrs)
                    {
                        if (attr is DataGridViewField)
                        {
                            if ((attr as DataGridViewField).IsShow)
                            {
                                columnShowState.ShowCol.Add(prop.Name);
                            }
                            else
                            {
                                columnShowState.HideCol.Add(prop.Name);
                            }
                        }
                        else if (attr is BrowsableAttribute)
                        {
                            if ((attr as BrowsableAttribute).Browsable)
                            {
                                columnShowState.ShowCol.Add(prop.Name);
                            }
                            else
                            {
                                columnShowState.HideCol.Add(prop.Name);
                            }
                        }
                        else
                        {
                            columnShowState.ShowCol.Add(prop.Name);
                        }
                    }
                }
                else
                {
                    columnShowState.ShowCol.Add(prop.Name);
                }
            }
            return columnShowState;
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static void ConfigrationComboBox<T>(ComboBox comboBox,
            List<T> dataSource, T selectedItem, string displayMember, string valueMember, FormOperation formOperation = FormOperation.New)
        {
            if (dataSource == null)
            {
                dataSource = new List<T>();
            }
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            if (formOperation == FormOperation.New)
            {
                if (dataSource.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            else
            {
                if (selectedItem == null)
                {
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    comboBox.SelectedItem = selectedItem;
                }
            }
        }
        public static void BindToEnum<TEnum>(this ComboBox comboBox)
        {
            var enumType = typeof(TEnum);

            var fields = enumType.GetMembers()
                                  .OfType<FieldInfo>()
                                  .Where(p => p.MemberType == MemberTypes.Field)
                                  .Where(p => p.IsLiteral)
                                  .ToList();

            var valuesByName = new Dictionary<string, object>();

            foreach (var field in fields)
            {
                var descriptionAttribute = field.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;

                var value = (int)field.GetValue(null);
                var description = string.Empty;

                if (!string.IsNullOrEmpty(descriptionAttribute?.Description))
                {
                    description = descriptionAttribute.Description;
                }
                else
                {
                    description = field.Name;
                }

                valuesByName[description] = value;
            }

            comboBox.DataSource = valuesByName.ToList();
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
        }
        public static bool CheckDouble(double value)
        {
            if (Double.IsNaN(value) || Double.IsInfinity(value) || Double.IsNegativeInfinity(value) || Double.IsPositiveInfinity(value))
            {
                return false;
            }
            return true;
        }
    }
    public static class ObjectExtensions
    {
        //public static string NullSafeToString(this object obj)
        //{
        //    return obj != null ? obj.ToString() : String.Empty;
        //}
        public static string NullSafeToString(object obj)
        {
            return obj != null ? obj.ToString() : String.Empty;
        }
        public static double NullSafeTodouble(object obj)
        {
            return obj != null ? Convert.ToDouble(obj) : 0;
        }
    }
}
