using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_LV3
{
    enum KVALITET
    {
        PRIHVATLJIV = 1,
        DOBAR = 2,
        ODLICAN = 3
    }

    class Jelo : Stavka
    {
        private int mNabavnaCena;
        private KVALITET mKvalitet;

        public Jelo() : base() { }

        public Jelo(String naziv, DateTime rokTrajanja, bool isVegan, int NabavnaCena, KVALITET Kvalitet)
            : base(naziv, rokTrajanja, isVegan, 1)
        {
            mNabavnaCena = NabavnaCena;
            mKvalitet = Kvalitet;
        }

        public override double Cena
        {
            get
            {
                int cena = mNabavnaCena * (int)mKvalitet;

                TimeSpan brDana = mRokTrajanja - DateTime.Now;

                if (brDana.Days < 3)
                {
                    return (cena * 0.8);
                }

                return cena;
            }
        }
        public override void Upisi(BinaryWriter writer)
        {
            base.Upisi(writer);

            writer.Write(mNabavnaCena);
            writer.Write((int)mKvalitet);
        }

        public override void Procitaj(BinaryReader reader)
        {
            base.Procitaj(reader);

            mNabavnaCena = reader.ReadInt32();
            mKvalitet = (KVALITET)reader.ReadInt32();
        }

        public override void Stampaj()
        {
            base.Stampaj();

            Console.WriteLine(Cena);
        }

    }
}
