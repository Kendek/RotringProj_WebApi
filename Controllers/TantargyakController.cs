using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotringWebApi2._0.DTO;
using RotringWebApi2._0.Entities;
using System.Net;

namespace RotringWebApi2._0.Controllers
{
    public class TantargyakController : Controller
    {
        private readonly RotringContext RotringContext;
        public TantargyakController(RotringContext RotringContext)
        {
            this.RotringContext = RotringContext;
        }

        [HttpGet("GetTantargyak")]
        public async Task<ActionResult<List<TantargyakDTO>>> Get()
        {
            var List = await RotringContext.Tantargyaks.Select(
                s => new TantargyakDTO
                {
                    Id = s.Id,
                    Tantargy = s.Tantargy,
                    Evfolyam = s.Evfolyam,
                    KozSzak = s.KozSzak,
                    Hetiora = s.Hetiora,
                    Evesora = s.Evesora
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

        [HttpGet("GetTantargyById")]
        public async Task<ActionResult<TantargyakDTO>> GetUserById(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            TantargyakDTO User = await RotringContext.Tantargyaks.Select(
                    s => new TantargyakDTO
                    {
                        Id = s.Id,
                        Tantargy = s.Tantargy,
                        Evfolyam = s.Evfolyam,
                        KozSzak = s.KozSzak,
                        Hetiora = s.Hetiora,
                        Evesora = s.Evesora
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

        [HttpPost("InsertTantargy")]
        public async Task<HttpStatusCode> InsertUser(TantargyakDTO Tantargy)
        {
            var entity = new Tantargyak()
            {
                Id = Tantargy.Id,
                Tantargy = Tantargy.Tantargy,
                Evfolyam = Tantargy.Evfolyam,
                KozSzak = Tantargy.KozSzak,
                Hetiora = Tantargy.Hetiora,
                Evesora = Tantargy.Evesora
            };

            RotringContext.Tantargyaks.Add(entity);
            await RotringContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateTantargy")]
        public async Task<HttpStatusCode> UpdateUser(TantargyakDTO Tantargy)
        {
            var entity = await RotringContext.Tantargyaks.FirstOrDefaultAsync(s => s.Id == Tantargy.Id);

            entity.Id = Tantargy.Id;
            entity.Tantargy = Tantargy.Tantargy;
            entity.Evfolyam = Tantargy.Evfolyam;
            entity.KozSzak = Tantargy.KozSzak;
            entity.Hetiora = Tantargy.Hetiora;
            entity.Evesora = Tantargy.Evesora;

            await RotringContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteTantargy/{Id}")]
        public async Task<HttpStatusCode> DeleteUser(int Id)
        {
            var entity = new Tantargyak()
            {
                Id = Id
            };
            RotringContext.Tantargyaks.Attach(entity);
            RotringContext.Tantargyaks.Remove(entity);
            await RotringContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
