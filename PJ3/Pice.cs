using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_LV3
{
    class Pice : Stavka
    {
        private int mKolicina;
        private int mCenaPoLitru;
        private bool mIsDomaca;

        public Pice() : base() { }

        public Pice(String naziv, DateTime rokTrajanja, bool isVegan, int mKolicina, int mCenaPoLitru, bool mIsDomaca)
            : base(naziv, rokTrajanja, isVegan, 0)
        {
            this.mKolicina = mKolicina;
            this.mCenaPoLitru = mCenaPoLitru;
            this.mIsDomaca = mIsDomaca;
        }
        public override double Cena
        {
            get
            {
                int cena = mCenaPoLitru * mKolicina;

                if (!mIsDomaca)
                {
                    return (cena * 1.3);
                }

                return cena;
            }
        }
        public override void Upisi(BinaryWriter writer)
        {
            base.Upisi(writer);

            writer.Write(mKolicina);
            writer.Write(mCenaPoLitru);
            writer.Write(mIsDomaca);
        }

        public override void Procitaj(BinaryReader reader)
        {
            base.Procitaj(reader);

            mKolicina = reader.ReadInt32();
            mCenaPoLitru = reader.ReadInt32();
            mIsDomaca = reader.ReadBoolean();
        }

        public override void Stampaj()
        {
            base.Stampaj();

            Console.WriteLine(Cena);
        }

    }
}
