using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace assignment3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
		}
		private ThreadStart demoThread = null;
		
		private void button1_Click(object sender, EventArgs e)
		{
			int a, b;
			a = int.Parse(textBox1.Text);
			b = int.Parse(textBox2.Text);
			for (int i = 1; i <= 10; i++)
			{
				try
				{
					demoThread = new ThreadStart(ThreadProcSafe);
					Thread childThread = new Thread(demoThread);
					childThread.Start();
					listBox1.Items.Add(a + " * " + i + " = " + a * i + " Wait for next");
					Thread.Sleep(b);
					childThread.Abort();
				}
				catch (ThreadAbortException error)
				{
					MessageBox.Show("" + error);
				}
			}
		}
		private void ThreadProcSafe()
		{
			for(int counter = 1;counter<=10;counter++)
			Thread.Sleep(500);
		}
	}
}
