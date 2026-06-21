using AirTrack.Server.Data;
using AirTrack.Server.Models.Aircraft;
using AirTrack.Server.Models.People;
using AirTrack.Server.Models.Scheduler;
using Microsoft.EntityFrameworkCore;

namespace AirTrack.Server.Data
    {
    public class DbHelper
        {
        private readonly AirTrackContext _context;

        public DbHelper(AirTrackContext context)
            {
            _context = context;
            }

        // ADD AIRCRAFT
        public async Task AddAircraft(AircraftBase aircraft)
            {
            _context.AircraftBases.Add(aircraft);
            await _context.SaveChangesAsync();
            }

        // UPDATE AIRCRAFT
        public async Task UpdateAircraft(AircraftBase aircraft)
            {
            _context.AircraftBases.Update(aircraft);
            await _context.SaveChangesAsync();
            }

        // DELETE AIRCRAFT
        public async Task DeleteAircraft(int id)
            {
            var aircraft = await _context.AircraftBases.FindAsync(id);
            if (aircraft is null)
                return;

            _context.AircraftBases.Remove(aircraft);
            await _context.SaveChangesAsync();
            }

        // GET ALL AIRCRAFT
        public async Task<List<AircraftBase>> GetAllAircraft()
            {
            return await _context.AircraftBases.ToListAsync();
            }

        // GET ONE AIRCRAFT
        public async Task<AircraftBase?> GetAircraft(int id)
            {
            return await _context.AircraftBases.FindAsync(id);
            }

        // ADD STUDENT
        public async Task AddStudent(Student student)
            {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            }

        // UPDATE STUDENT
        public async Task UpdateStudent(Student updated)
            {
            var existing = await _context.Students.FindAsync(updated.Id);

            if (existing == null)
                return;

            _context.Entry(existing).CurrentValues.SetValues(updated);

            await _context.SaveChangesAsync();
            }


        // DELETE STUDENT
        public async Task DeleteStudent(int id)
            {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                return;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            }

        // GET ALL STUDENTS
        public async Task<List<Student>> GetAllStudents()
            {
            return await _context.Students
                .Include(s => s.AssignedInstructor)
                .ToListAsync();
            }

        // GET ONE STUDENT
        public async Task<Student?> GetStudent(int id)
            {
            return await _context.Students
                .Include(s => s.AssignedInstructor)
                .FirstOrDefaultAsync(s => s.Id == id);
            }
                
        // ADD INSTRUCTOR
        public async Task AddInstructor(Instructor instructor)
            {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            }

        // UPDATE INSTRUCTOR
        public async Task UpdateInstructor(Instructor updated)
            {
            var existing = await _context.Instructors.FindAsync(updated.Id);
            if (existing == null)
                return;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();
            }

        // DELETE INSTRUCTOR
        public async Task DeleteInstructor(int id)
            {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor is null)
                return;

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            }

        // GET ALL INSTRUCTORS
        public async Task<List<Instructor>> GetAllInstructors()
            {
            return await _context.Instructors.ToListAsync();
            }

        // GET ONE INSTRUCTOR
        public async Task<Instructor?> GetInstructor(int id)
            {
            return await _context.Instructors.FindAsync(id);
            }
       
        // ADD MECHANIC
        public async Task AddMechanic(Mechanic mechanic)
            {
            _context.Mechanics.Add(mechanic);
            await _context.SaveChangesAsync();
            }

        // UPDATE MECHANIC
        public async Task UpdateMechanic(Mechanic updated)
            {
            var existing = await _context.Mechanics.FindAsync(updated.Id);
            if (existing == null)
                return;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();
            }

        // DELETE MECHANIC
        public async Task DeleteMechanic(int id)
            {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic is null)
                return;

            _context.Mechanics.Remove(mechanic);
            await _context.SaveChangesAsync();
            }

        // GET ALL MECHANICS
        public async Task<List<Mechanic>> GetAllMechanics()
            {
            return await _context.Mechanics.ToListAsync();
            }

        // GET ONE MECHANIC
        public async Task<Mechanic?> GetMechanic(int id)
            {
            return await _context.Mechanics.FindAsync(id);
            }

        // ADD EVENT
        public async Task AddEvent(FlightEvent evt)
            {
            _context.FlightEvents.Add(evt);
            await _context.SaveChangesAsync();
            }

        // UPDATE EVENT
        public async Task UpdateEvent(FlightEvent updated)
            {
            var existing = await _context.FlightEvents.FindAsync(updated.Id);
            if (existing == null)
                return;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();
            }

        // DELETE EVENT
        public async Task DeleteEvent(int id)
            {
            var evt = await _context.FlightEvents.FindAsync(id);
            if (evt is null)
                return;

            _context.FlightEvents.Remove(evt);
            await _context.SaveChangesAsync();
            }

        // GET ALL EVENTS
        public async Task<List<FlightEvent>> GetAllEvents()
            {
            return await _context.FlightEvents.ToListAsync();
            }

        // GET ONE EVENT
        public async Task<FlightEvent?> GetEvent(int id)
            {
            return await _context.FlightEvents.FindAsync(id);
            }



        }
    }
