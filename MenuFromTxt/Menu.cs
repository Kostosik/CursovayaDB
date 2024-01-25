using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace CursovayaDB
{
    public class Menu : MenuStrip
    {
        public Menu(string fileName, Form parent)
        {
            this.Parent= parent;

            string[] menuLines = System.IO.File.ReadAllLines(fileName);

            List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();
            ToolStripMenuItem currentItem = null;

            string[] topLevelMethods = new string[menuLines.Length];
            int index = 0;
            foreach (string line in menuLines)
            {
                if (line[0] == '0')
                {
                    ToolStripMenuItem topLevelItem = new ToolStripMenuItem();
                    menuItems.Add(topLevelItem);

                    CreateMenuButtons(line, topLevelItem);

                    string[] lines = line.Split('/');
                    topLevelMethods[index] = lines[lines.Length - 2];
                    index++;
                    topLevelItem.Text = lines[1];
                    this.Items.Add(topLevelItem);

                    currentItem = topLevelItem;
                }
                if (line[0] == '1')
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();

                    CreateMenuButtons(line, subItem);

                    string[] lines = line.Split('/');
                    subItem.Text = lines[1];
                    currentItem.DropDownItems.Add(subItem);

                    createMethods(lines[lines.Length - 2], subItem, parent, lines[lines.Length-1]);
                }
            }

            index = 0;
            foreach (ToolStripMenuItem menuItem in menuItems)
            {
                if (menuItem.DropDownItems.Count > 0)
                    continue;
                createMethods(topLevelMethods[index], menuItem,parent,null);
                index++;
            }
        }


        public Menu (Form parent,string MenuLines)
        {
            this.Parent = parent;

            string[] menuLines = MenuLines.Split('\n');


            List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();
            ToolStripMenuItem currentItem = null;

            string[] topLevelMethods = new string[menuLines.Length];
            int index = 0;
            foreach (string line in menuLines)
            {
                if (line[0] == '0')
                {
                    ToolStripMenuItem topLevelItem = new ToolStripMenuItem();
                    menuItems.Add(topLevelItem);

                    CreateMenuButtons(line, topLevelItem);

                    string[] lines = line.Split('/');
                    topLevelMethods[index] = lines[lines.Length - 2];
                    index++;
                    topLevelItem.Text = lines[1];
                    this.Items.Add(topLevelItem);

                    currentItem = topLevelItem;
                }
                if (line[0] == '1')
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();

                    CreateMenuButtons(line, subItem);

                    string[] lines = line.Split('/');
                    subItem.Text = lines[1];
                    currentItem.DropDownItems.Add(subItem);

                    createMethods(lines[lines.Length - 2], subItem, parent, lines[lines.Length - 1]);
                }
            }

            index = 0;
            foreach (ToolStripMenuItem menuItem in menuItems)
            {
                if (menuItem.DropDownItems.Count > 0)
                    continue;
                createMethods(topLevelMethods[index], menuItem, parent, null);
                index++;
            }
        }

        private void CreateMenuButtons(string line, ToolStripMenuItem button)
        {
            line = line.Remove(0, 2);
            if (line.Contains('1'))
            {
                button.Enabled = false;
            }
            if (line.Contains('2'))
            {
                button.Visible = false;
            }
        }

        private void createMethods(string methodName, ToolStripMenuItem button,Form parent,string tableName)
        {
            MethodInfo methodInfo = typeof(AbstractMethods).GetMethod(methodName);

            AssemblyName assemblyName = new AssemblyName("assemblyname");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);

            TypeBuilder typeBuilder = moduleBuilder.DefineType("AbstractMethods", TypeAttributes.Public | TypeAttributes.Class);
            MethodBuilder methodBuilder;

            if (methodName == "NULL")
                return;

            if (methodName == "showInformationAdmin" || methodName == "showInformationUser")
            {
                methodBuilder = typeBuilder.DefineMethod(methodName, MethodAttributes.Static | MethodAttributes.Public,
    typeof(void), new Type[] { typeof(ToolStripMenuItem), typeof(Form), typeof(string) });
            }
            else
            {
                methodBuilder = typeBuilder.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.Static,
                    typeof(void), new Type[] { typeof(ToolStripMenuItem), typeof(Form), typeof(string) });
            }

            ILGenerator iLGenerator = methodBuilder.GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldstr, "");
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Ldarg_2);
            iLGenerator.Emit(OpCodes.Call, methodInfo);
            iLGenerator.Emit(OpCodes.Ret);

            Type type = typeBuilder.CreateType();
            MethodInfo dynamicMethod = type.GetMethod(methodName);

            if(methodName== "showInformationAdmin" || methodName == "showInformationUser")
                button.Click += (sender, args) => dynamicMethod.Invoke(null, new object[] { button, parent,tableName});
            else
                button.Click += (sender, args) => dynamicMethod.Invoke(null, new object[] { button, parent, tableName });
        }
    }
}
