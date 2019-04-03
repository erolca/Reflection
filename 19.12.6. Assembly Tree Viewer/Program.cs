using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Text;

public class Form1 : System.Windows.Forms.Form
{
    private System.Windows.Forms.MainMenu mainMenu1 = new System.Windows.Forms.MainMenu();
    private System.Windows.Forms.MenuItem menuItem1 = new System.Windows.Forms.MenuItem();
    private System.Windows.Forms.MenuItem mnuOpen = new System.Windows.Forms.MenuItem();
    private System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
    private Assembly mAssembly;
    private System.Windows.Forms.TreeView carAssembly = new System.Windows.Forms.TreeView();
    private System.Windows.Forms.PropertyGrid pgObject = new System.Windows.Forms.PropertyGrid();

    public Form1()
    {
        this.SuspendLayout();

        this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuItem1 });
        this.menuItem1.Index = 0;
        this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.mnuOpen });
        this.menuItem1.Text = "&File";

        this.mnuOpen.Index = 0;
        this.mnuOpen.Text = "&Open";
        this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);

        this.openFileDialog1.CheckFileExists = false;
        this.openFileDialog1.CheckPathExists = false;
        this.openFileDialog1.Filter = "Assemblies|*.exe;*.dll";
        this.openFileDialog1.ValidateNames = false;

        this.carAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.carAssembly.ImageIndex = -1;
        this.carAssembly.Location = new System.Drawing.Point(8, 8);
        this.carAssembly.Name = "carAssembly";
        this.carAssembly.SelectedImageIndex = -1;
        this.carAssembly.Size = new System.Drawing.Size(672, 400);
        this.carAssembly.TabIndex = 0;
        this.carAssembly.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.carAssembly_AfterSelect);

        this.pgObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.pgObject.BackColor = System.Drawing.Color.Gray;
        this.pgObject.CommandsBackColor = System.Drawing.Color.Gray;
        this.pgObject.CommandsForeColor = System.Drawing.Color.Gray;
        this.pgObject.CommandsVisibleIfAvailable = true;
        this.pgObject.HelpBackColor = System.Drawing.Color.Gray;
        this.pgObject.HelpForeColor = System.Drawing.Color.White;
        this.pgObject.HelpVisible = false;
        this.pgObject.LargeButtons = false;
        this.pgObject.LineColor = System.Drawing.Color.Gray;
        this.pgObject.Location = new System.Drawing.Point(8, 416);
        this.pgObject.Name = "pgObject";
        this.pgObject.Size = new System.Drawing.Size(672, 128);
        this.pgObject.TabIndex = 1;
        this.pgObject.Text = "propertyGrid1";
        this.pgObject.ToolbarVisible = false;
        this.pgObject.ViewBackColor = System.Drawing.Color.Gray;
        this.pgObject.ViewForeColor = System.Drawing.Color.White;

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(688, 553);
        this.Controls.Add(this.pgObject);
        this.Controls.Add(this.carAssembly);
        this.Menu = this.mainMenu1;
        this.Text = "Assembly Viewer";
        this.ResumeLayout(false);

    }
    [STAThread]
    static void Main()
    {
        Application.Run(new Form1());
    }

    private void mnuOpen_Click(object sender, System.EventArgs e)
    {
        if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                mAssembly = Assembly.LoadFile(openFileDialog1.FileName);
                PopulateTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void PopulateTree()
    {
        TreeNode newNode = new TreeNode(mAssembly.GetName().Name);
        newNode.Tag = mAssembly;
        carAssembly.Nodes.Add(newNode);

        foreach (Module mod in mAssembly.GetModules())
        {
            AddModule(mod, newNode);
        }
    }

    private void AddModule(Module mod, TreeNode parent)
    {
        TreeNode newNode = new TreeNode(mod.Name);
        newNode.Tag = mod;
        parent.Nodes.Add(newNode);

        foreach (Type t in mod.GetTypes())
        {
            AddType(t, newNode);
        }
    }

    private void AddType(Type t, TreeNode parent)
    {
        TreeNode newNode = new TreeNode(t.Name);
        newNode.Tag = t;
        TreeNode curType;
        TreeNode curMember;

        curType = new TreeNode("Constructors");
        foreach (ConstructorInfo constructor in t.GetConstructors())
        {
            curMember = new TreeNode(constructor.Name);
            curMember.Tag = constructor;
            curType.Nodes.Add(curMember);
        }
        newNode.Nodes.Add(curType);

        curType = new TreeNode("Methods");
        foreach (MethodInfo method in t.GetMethods())
        {
            string methodString = method.Name + "( ";
            int count = method.GetParameters().Length;

            foreach (ParameterInfo param in method.GetParameters())
            {
                methodString += param.ParameterType;
                if (param.Position < count - 1)
                    methodString += ", ";
            }
            methodString += " )";
            curMember = new TreeNode(methodString);
            curMember.Tag = method;
            curType.Nodes.Add(curMember);
        }
        newNode.Nodes.Add(curType);

        curType = new TreeNode("Properties");
        foreach (PropertyInfo property in t.GetProperties())
        {
            curMember = new TreeNode(property.Name);
            curMember.Tag = property;
            curType.Nodes.Add(curMember);
        }
        newNode.Nodes.Add(curType);

        curType = new TreeNode("Fields");
        foreach (FieldInfo field in t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField))
        {
            string fieldInfo = field.FieldType.Name;
            fieldInfo += " " + field.Name;
            curMember = new TreeNode(fieldInfo);
            curMember.Tag = field;
            curType.Nodes.Add(curMember);
        }
        newNode.Nodes.Add(curType);

        curType = new TreeNode("Events");
        foreach (EventInfo curEvent in t.GetEvents())
        {
            string eventInfo = curEvent.Name;
            eventInfo += " Delegate Type=" + curEvent.EventHandlerType;
            curMember = new TreeNode(eventInfo);
            curMember.Tag = curEvent;
            curType.Nodes.Add(curMember);
        }
        newNode.Nodes.Add(curType);

        parent.Nodes.Add(newNode);
    }

    private void carAssembly_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
        if (e.Node.Tag != null)
        {
            pgObject.SelectedObject = e.Node.Tag;
        }
        else
        {
            pgObject.SelectedObject = null;
        }
    }
}