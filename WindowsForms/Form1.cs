using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      var button = new System.Windows.Forms.Button();
      SuspendLayout();
      // 
      // button1
      // 
      button.Location = new System.Drawing.Point(13, 24);
//      button1.Name = "button1";
      button.Size = new System.Drawing.Size(23, 23);
      button.TabIndex = 0;
      button.Text = "*";
      //button1.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(284, 262);
      Controls.Add(button);
      Name = "Form1";
      Text = "Minesweeper";
      ResumeLayout(false);

    }
  }
}
