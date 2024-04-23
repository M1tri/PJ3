using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PJ_LV3
{
    class Restoran
    {
        private List<Stavka> mMeni;
        private int mMeniCount;
        private String mNaziv;

        public Restoran(String Naziv)
        {
            mMeni = new List<Stavka>();
            mMeniCount = 0;
            mNaziv = Naziv;
        }

        public void Insert(Stavka stavka)
        {
            mMeni.Add(stavka);
            mMeniCount++;
        }

        public void Sortiraj()
        {
            for (int i = 0; i < mMeniCount - 1; i++)
            {
                for (int j = i + 1; j < mMeniCount; j++)
                {
                    if (mMeni[i].Cena > mMeni[j].Cena)
                    {
                        Stavka pom = mMeni[i];
                        mMeni[i] = mMeni[j];
                        mMeni[j] = pom;
                    }
                }
            }
        }

        public void IzbaciIsteklo()
        {
            for (int i = 0; i < mMeniCount; i++)
            {
                if (mMeni[i].IstekoRok())
                {
                    for (int j = i; j < mMeniCount - 1; j++)
                    {
                        mMeni[j] = mMeni[j + 1];
                    }
                    mMeniCount--;
                }
            }
        }

        public void Upisi(String path)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create));

            bw.Write(mNaziv);
            bw.Write(mMeniCount);

            for (int i = 0; i < mMeniCount; i++)
            {
                bw.Write((int)mMeni[i].Tip);
                mMeni[i].Upisi(bw);
            }

            bw.Close();
        }

        public void Procitaj(String path)
        {
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));

            mNaziv = br.ReadString();
            mMeniCount = 0;
            int count = br.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                int tip = br.ReadInt32();

                if (tip == 0)
                {
                    Pice novo = new Pice();
                    novo.Procitaj(br);
                    Insert(novo);
                }
                else if (tip == 1)
                {
                    Jelo novo = new Jelo();
                    novo.Procitaj(br);
                    Insert(novo);
                }

            }
        }

        public void Prikazi()
        {
            Console.WriteLine(mNaziv);

            for (int i = 0; i < mMeniCount; i++)
            {
                mMeni[i].Stampaj();
                Console.WriteLine();
            }
        }

        public void CheckVegan()
        {
            for (int i = 0; i < mMeniCount; i++)
            {
                if (mMeni[i].IsVegan)
                {
                    return;
                }
            }

            throw new VeganUnfriendly("Ne postoji veganska opcija u meniju");
        }

    }
}
