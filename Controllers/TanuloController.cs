using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotringWebApi2._0.DTO;
using RotringWebApi2._0.Entities;
using System.Net;

namespace RotringWebApi2._0.Controllers
{
    public class TanuloController : Controller
    {
        private readonly RotringContext RotringContext;
        public TanuloController(RotringContext RotringContext)
        {
            this.RotringContext = RotringContext;
        }

        [HttpGet("GetTanulos")]
        public async Task<ActionResult<List<TanuloDTO>>> Get()
        {
            var List = await RotringContext.Tanulos.Select(
                s => new TanuloDTO
                {
                    Id = s.Id,
                    Nev = s.Nev,
                    SzulHely = s.SzulHely,
                    SzulIdo = s.SzulIdo,
                    Anyjanev = s.Anyjanev,
                    Lakcim = s.Lakcim,
                    BeirIdo = s.BeirIdo,
                    Szak = s.Szak,
                    Osztaly = s.Osztaly,
                    Kolise = s.Kolise,
                    Koli = s.Koli,
                    Naploszam = s.Naploszam,
                    Torzsszam = s.Torzsszam,
                    Matek = s.Matek,
                    Irodalom = s.Irodalom,
                    Nyelvtan = s.Nyelvtan,
                    Idegennyelv = s.Idegennyelv,
                    Tesi = s.Tesi,
                    Fizika = s.Fizika,
                    Szakma = s.Szakma
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetTanuloById")]
        public async Task<ActionResult<TanuloDTO>> GetUserById(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            TanuloDTO User = await RotringContext.Tanulos.Select(
                    s => new TanuloDTO
                    {
                        Id = s.Id,
                        Nev = s.Nev,
                        SzulHely = s.SzulHely,
                        SzulIdo = s.SzulIdo,
                        Anyjanev = s.Anyjanev,
                        Lakcim = s.Lakcim,
                        BeirIdo = s.BeirIdo,
                        Szak = s.Szak,
                        Osztaly = s.Osztaly,
                        Kolise = s.Kolise,
                        Koli = s.Koli,
                        Naploszam = s.Naploszam,
                        Torzsszam = s.Torzsszam,
                        Matek = s.Matek,
                        Irodalom = s.Irodalom,
                        Nyelvtan = s.Nyelvtan,
                        Idegennyelv = s.Idegennyelv,
                        Tesi = s.Tesi,
                        Fizika = s.Fizika,
                        Szakma = s.Szakma
                    })
                .FirstOrDefaultAsync(s => s.Id == Id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

        [HttpPost("InsertTanulo")]
        public async Task<HttpStatusCode> InsertUser(TanuloDTO Tanulo)
        {
            var entity = new Tanulo()
            {
                Id = Tanulo.Id,
                Nev = Tanulo.Nev,
                SzulHely = Tanulo.SzulHely,
                SzulIdo = Tanulo.SzulIdo,
                Anyjanev = Tanulo.Anyjanev,
                Lakcim = Tanulo.Lakcim,
                BeirIdo = Tanulo.BeirIdo,
                Szak = Tanulo.Szak,
                Osztaly = Tanulo.Osztaly,
                Kolise = Tanulo.Kolise,
                Koli = Tanulo.Koli,
                Naploszam = Tanulo.Naploszam,
                Torzsszam = Tanulo.Torzsszam,
                Matek = Tanulo.Matek,
                Irodalom = Tanulo.Irodalom,
                Nyelvtan = Tanulo.Nyelvtan,
                Idegennyelv = Tanulo.Idegennyelv,
                Tesi = Tanulo.Tesi,
                Fizika = Tanulo.Fizika,
                Szakma = Tanulo.Szakma
            };

            RotringContext.Tanulos.Add(entity);
            await RotringContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateTanulo")]
        public async Task<HttpStatusCode> UpdateUser(TanuloDTO Tanulo)
        {
            var entity = await RotringContext.Tanulos.FirstOrDefaultAsync(s => s.Id == Tanulo.Id);

            entity.Id = Tanulo.Id;
            entity.Nev = Tanulo.Nev;
            entity.SzulHely = Tanulo.SzulHely;
            entity.SzulIdo = Tanulo.SzulIdo;
            entity.Anyjanev = Tanulo.Anyjanev;
            entity.Lakcim = Tanulo.Lakcim;
            entity.BeirIdo = Tanulo.BeirIdo;
            entity.Szak = Tanulo.Szak;
            entity.Osztaly = Tanulo.Osztaly;
            entity.Kolise = Tanulo.Kolise;
            entity.Koli = Tanulo.Koli;
            entity.Naploszam = Tanulo.Naploszam;
            entity.Torzsszam = Tanulo.Torzsszam;
            entity.Matek = Tanulo.Matek;
            entity.Irodalom = Tanulo.Irodalom;
            entity.Nyelvtan = Tanulo.Nyelvtan;
            entity.Idegennyelv = Tanulo.Idegennyelv;
            entity.Tesi = Tanulo.Tesi;
            entity.Fizika = Tanulo.Fizika;
            entity.Szakma = Tanulo.Szakma;

            await RotringContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteTanulo/{Id}")]
        public async Task<HttpStatusCode> DeleteTanulo(int Id)
        {
            var entity = new Tanulo()
            {
                Id = Id
            };
            RotringContext.Tanulos.Attach(entity);
            RotringContext.Tanulos.Remove(entity);
            await RotringContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
