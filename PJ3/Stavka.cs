using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_LV3
{
    abstract class Stavka
    {
        protected String mNaziv;
        protected DateTime mRokTrajanja;
        protected bool mIsVegan;
        private int mTip;

        public Stavka() { }

        public Stavka(String naziv, DateTime rokTrajanja, bool isVegan, int tip)
        {
            mNaziv = naziv;
            mRokTrajanja = rokTrajanja;
            mIsVegan = isVegan;
            mTip = tip;
        }

        public virtual void Upisi(BinaryWriter writer)
        {
            writer.Write(mNaziv);
            writer.Write(mRokTrajanja.ToString());
            writer.Write(mIsVegan);
        }

        public virtual void Procitaj(BinaryReader reader)
        {
            mNaziv = reader.ReadString();
            String datum = reader.ReadString();
            mRokTrajanja = DateTime.Parse(datum);
            mIsVegan = reader.ReadBoolean();
        }

        public bool IstekoRok()
        {
            if (mRokTrajanja < DateTime.Now)
            {
                return true;
            }

            return false;
        }

        public virtual void Stampaj()
        {
            Console.WriteLine(mNaziv.ToString());
            Console.WriteLine(mRokTrajanja);
        }

        public abstract double Cena { get; }

        public int Tip { get { return mTip; } }

        public bool IsVegan { get { return mIsVegan; } }

    }
}
