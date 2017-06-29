using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cat Cats = new Cat();
            //Cats.ShoutNum = 5;
            //MessageBox.Show(Cats.Shout());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Dog Dogs = new Dog();
            //Dogs.ShoutNum = 5;
            //MessageBox.Show(Dogs.Shout());
        }

        interface IChange 
        {
            string ChangeThing(string thing);
        }

        class MachineCat : Cat, IChange 
        {
            public MachineCat(string name)
                : base(name) 
            {
                
            }
            public MachineCat()
                : base() 
            {
            
            }
            public string ChangeThing(string thing) 
            {
                return base.Shout() + " 我有萬能的口袋，我可變出:" + thing;
            }
        }
        abstract class Animal
        {
            protected string name = "";
            public Animal(string name)
            {
                this.name = name;
            }
            public Animal()
            {
                this.name = "我是無名";
            }
            protected int shoutNum = 3;
            public int ShoutNum
            {
                get
                {
                    return shoutNum;
                }
                set
                {
                    shoutNum = value;
                }
            }
            public string Shout()
            {
                string result = "";
                for (int i = 0; i < shoutNum; i++)
                    result += GetShoutSound() + ",";
                return result;
            }
            protected abstract string GetShoutSound();


        }


        class Cat : Animal
        {
            public Cat()
                : base()
            { }
            public Cat(string name)
                : base(name)
            { }

            protected override string GetShoutSound()
            {
                return "喵";
            }

        }

        class Dog : Animal
        {
            public Dog()
                : base()
            { }
            public Dog(string name)
                : base(name)
            { }
            protected override string GetShoutSound()
            {
                return "汪";
            }
        }

        class Cattle : Animal
        {
            public Cattle()
                : base()
            { }
            public Cattle(string name)
                : base(name)
            { }
            protected override string GetShoutSound()
            {
                return "牛";
            }
        }
        class Sheep : Animal
        {
            public Sheep()
                : base()
            { }
            public Sheep(string name)
                : base(name)
            { }
            protected override string GetShoutSound()
            {
                return "眫 ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MachineCat mcat = new MachineCat("小叮噹");
            MessageBox.Show(mcat.ChangeThing("各式各樣東西"));
        }


        IList arrayAnimal;

        private void button5_Click(object sender, EventArgs e)
        {
            arrayAnimal = new ArrayList();
            arrayAnimal.Add(new Cat("小花"));
            arrayAnimal.Add(new Dog("阿毛"));
            arrayAnimal.Add(new Cat("咪咪"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (arrayAnimal !=null)
            {
                foreach (Animal item in arrayAnimal)
                {
                    MessageBox.Show(item.Shout());
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            MainCat mc = new MainCat("tom");
            Mouse mu1 = new Mouse("Jerry");
            Mouse mu2 = new Mouse("Jeck");
            mc.CatShout += new MainCat.CateShoutEventHandler(mu1.Run);
            mc.CatShout += new MainCat.CateShoutEventHandler(mu2.Run);
            mc.Shout();
        }
        public class CatShoutEventArgs : EventArgs 
        {
            public string Name { get; set; }
        }
        class MainCat 
        {

            private string name;
            public MainCat(string name) 
            {
                this.name = name;
            }
            //public delegate void CatShoutEventHandler();
            //public event CatShoutEventHandler CatShout;

            //public void Shout() 
            //{
            //    MessageBox.Show("喵 我是 " + name);
            //    if (CatShout != null)
            //        CatShout();
            //}
            public delegate void CateShoutEventHandler(object sender, CatShoutEventArgs args);
            public event CateShoutEventHandler CatShout;
            public void Shout() 
            {
                MessageBox.Show("喵 我是 " + name);
                if (CatShout != null)
                {
                    CatShoutEventArgs e = new CatShoutEventArgs();
                    e.Name = this.name;
                    CatShout(this, e);
                }
            }
        }
        class Mouse
        {
            private string name;
            public Mouse(string name) 
            {
                this.name = name;
            }
            //public void Run() 
            //{
            //    MessageBox.Show("老貓來,"+ name + "快跑");
            //}
            public void Run(object sender, CatShoutEventArgs args) 
            {
                MessageBox.Show("老貓來," + name + "快跑");
            }
        }
    }

}
