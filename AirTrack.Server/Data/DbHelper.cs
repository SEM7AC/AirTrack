using AirTrack.Server.Data;
using AirTrack.Server.Models.Aircraft;
using AirTrack.Server.Models.FormModel;
using AirTrack.Server.Models.Maintenance;
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

        // GET OPEN SQUAWKS FOR AIRCRAFT
        public async Task<List<Squawk>> GetOpenSquawks(int aircraftId)
            {
            return await _context.Squawks
                .Where(s => s.AircraftId == aircraftId && s.ResolvedAt == null)
                .OrderByDescending(s => s.ReportedAt)
                .ToListAsync();
            }

        // COUNT OPEN SQUAWKS
        public async Task<int> GetOpenSquawksCount(int aircraftId)
            {
            return await _context.Squawks
                .CountAsync(s => s.AircraftId == aircraftId && s.ResolvedAt == null);
            }

        // ADD SQUAWK
        public async Task AddSquawk(Squawk squawk)
            {
            _context.Squawks.Add(squawk);
            await _context.SaveChangesAsync();
            }

        // RESOLVE SQUAWK
        public async Task ResolveSquawk(int squawkId, string resolutionNotes, string mechanicSignoff)
            {
            var squawk = await _context.Squawks.FindAsync(squawkId);
            if (squawk is null)
                return;

            squawk.ResolutionNotes = resolutionNotes;
            squawk.MechanicSignoff = mechanicSignoff;
            squawk.ResolvedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            }

        // GET ONE SQUAWK
        public async Task<Squawk?> GetSquawk(int id)
            {
            return await _context.Squawks.FindAsync(id);
            }
        
        // HAS GROUNDING SQUAWK
        public async Task<bool> AircraftHasGroundingSquawk(int aircraftId)
            {
            return await _context.Squawks
                .AnyAsync(s => s.AircraftId == aircraftId &&
                               s.IsGrounding &&
                               s.ResolvedAt == null);
            }

        // GET MAINTENANCE
        public async Task<(AircraftBase? Aircraft, List<Squawk> OpenSquawks)> GetMaintenanceAircraftAsync(int id)
            {
            var aircraft = await GetAircraft(id);
            var openSquawks = await GetOpenSquawks(id);
            var events = await GetAllEvents();

            if (aircraft is not null)
                {
                await aircraft.RefreshSquawksAsync(this);
                await aircraft.RefreshOperationalStateAsync(this, events);
                }

            return (aircraft, openSquawks);
            }

        // ADD SQUAWK + REFRESH
        public async Task AddSquawkAndRefreshAsync(AircraftBase aircraft, string description, bool isGrounding)
            {
            var squawk = new Squawk
                {
                AircraftId = aircraft.Id,
                Description = description,
                IsGrounding = isGrounding,
                ReportedAt = DateTime.UtcNow
                };

            await AddSquawk(squawk);

            var events = await GetAllEvents();

            await aircraft.RefreshSquawksAsync(this);
            await aircraft.RefreshOperationalStateAsync(this, events);
            }
        
        // RESOLVE SQUAWK + REFRESH
        public async Task ResolveSquawkAndRefreshAsync(AircraftBase aircraft, int squawkId, string notes, string signoff)
            {
            await ResolveSquawk(squawkId, notes, signoff);

            var events = await GetAllEvents();

            await aircraft.RefreshSquawksAsync(this);
            await aircraft.RefreshOperationalStateAsync(this, events);
            }

        // SAVE MX INFO + REFRESH
        public async Task<(List<AircraftBase> AircraftList, List<Squawk> OpenSquawks)> SaveMxInfoAndRefreshAsync(AircraftBase aircraft)
            {
            await aircraft.RefreshSquawksAsync(this);

            var events = await GetAllEvents();
            await aircraft.RefreshOperationalStateAsync(this, events);

            await UpdateAircraft(aircraft);

            var list = await GetAllAircraft();
            var squawks = await GetOpenSquawks(aircraft.Id);

            return (list, squawks);
            }

        public List<FlightEvent> FilterEventsByAircraft(List<FlightEvent> events, int aircraftId)
            {
            return events.Where(ev => ev.AircraftId == aircraftId).ToList();
            }

        public List<FlightEvent> FilterEventsByDate(List<FlightEvent> events, DateTime date)
            {
            return events.Where(ev => TimeHelper.ToPacific(ev.Start).Date == date.Date).ToList();

            }

        // SCHEDULER REFRESH 
        public async Task<(List<AircraftBase> Aircraft, List<Instructor> Instructors, List<Student> Students,List<Mechanic> Mechanics,List<FlightEvent> Events)> RefreshSchedulerAsync(DateTime date)
                {
                var aircraft = await GetAllAircraft();
                var instructors = await GetAllInstructors();
                var students = await GetAllStudents();
                var mechanics = await GetAllMechanics();

                var allEvents = await GetAllEvents();

                // Convert all event timestamps to Pacific
                
                var dayEvents = FilterEventsByDate(allEvents, date);

                return (aircraft, instructors, students, mechanics, dayEvents);
                }

        public FlightEvent MapToEntity(FlightEventFormModel model)
            {
            return new FlightEvent
                {
                Id = model.Id ?? 0,
                AircraftId = model.AircraftId!.Value,
                InstructorId = model.InstructorId,
                StudentId = model.StudentId,
                MechanicId = model.MechanicId,
                Start = TimeHelper.ToUtc(model.Start),
                End = TimeHelper.ToUtc(model.End)
                };
            }

        public FlightEventFormModel MapToFormModel(FlightEvent ev)
            {
            return new FlightEventFormModel
                {
                Id = ev.Id,
                AircraftId = ev.AircraftId,
                InstructorId = ev.InstructorId,
                StudentId = ev.StudentId,
                MechanicId = ev.MechanicId,
                Start = ev.Start,
                End = ev.End
                };
            }

        public string GetEventLabel(FlightEvent ev, List<Instructor> instructors, List<Student> students)
            {
            var instructor = instructors.FirstOrDefault(i => i.Id == ev.InstructorId);
            var student = students.FirstOrDefault(s => s.Id == ev.StudentId);

            if (instructor is not null && student is not null)
                return $"{instructor.LastName}/{student.LastName}";

            if (instructor is not null)
                return instructor.LastName;

            if (student is not null)
                return student.LastName;

            return $"{ev.Start:HH:mm}-{ev.End:HH:mm}";
            }

        public string GetEventStyle(FlightEvent ev)
            {
            double hourHeight = 60;
            double pxPerMinute = hourHeight / 60.0;

            var start = ev.Start;
            var end = ev.End;

            double startOffset = Math.Ceiling(start.TimeOfDay.TotalMinutes * pxPerMinute);
            double duration = Math.Ceiling((end - start).TotalMinutes * pxPerMinute);

            if (duration < 15)
                duration = 15;

            return $"top:{startOffset}px;height:{duration}px;";
            }

        public FlightEventFormModel CreateDefaultEvent(DateTime date, bool isDelete = false)
            {
            if (isDelete)
                {
                return new FlightEventFormModel
                    {
                    Start = date.Date,
                    End = date.Date
                    };
                }

            return new FlightEventFormModel
                {
                Start = date.Date.AddHours(8),
                End = date.Date.AddHours(9)
                };
            }










        }
    }
