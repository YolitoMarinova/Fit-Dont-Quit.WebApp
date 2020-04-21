namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;

    public class GroupTrainingsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.GroupTrainings.Any())
            {
                return;
            }

            var firstGroupTraining = new GroupTraining
            {
                Name = "Kangoo Jumps",
                Description = "Kangoo Jumps is a funny and no less intense aerobic program. It is carried out with the help of special spring shoes that provide a huge amount of freedom and the amplitude of motion both on the ground and in the air. Despite its strange design, the shoes have a lightening and relieving effect on the joints, reducing the shock impact on the ankles, knees, shins, hips, lower back and spine by up to 80%. This leads to improvements in the muscles of the lower body, abdomen and back. Exercises are incredibly easy to perform, and classes are run by certified instructors who mostly monitor to see if participants are having fun while jumping against the background of vivid club rhythms. Kangoo Jumps is one of the most affordable cardio programs and, at the same time, an extremely effective way to address overweight, regardless of weight and age.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587233366/kango-jumps.jpg.jpg",
            };

            var secondGroupTraining = new GroupTraining
            {
                Name = "Spining",
                Description = "Spinning is a cardio exercise performed on specially adapted static devices (spinners) simulating biking. During the training session, the participants in this group activity undergo different loading phases, typical of this type of sport – sprint, marathon, climb and downhill. Spinning activities are conducted under the supervision of a certified coach, who sets the pace and chooses the choreography, taking into account the physical fitness of the group. The workout begins with a short warm up, passes through a more intense main part and ends with a lighter load to return the heart rate of the participants in normal values. Group Spinning activities increase endurance and muscle strength in the lower body. In addition, stomach, shoulders and triceps are loaded. This makes it an appropriate exercise for melting excess fat and maintaining an excellent physical shape.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587233516/Spinning_3.jpg.jpg",
            };

            var thirdGroupTraining = new GroupTraining
            {
                Name = "Crossfit",
                Description = "Crossfit is the perfect combination of training programs. Participants in this group exercise perform exercises specific to athletics, gymnastics, weightlifting and even water sports at the same time, within one session. Techniques are extremely varied. These include squats, lunges, jogging, jumps and arcs, pushups and crunches. Typically, exercises are performed by means of devices to further increase the load on all muscle groups. Kettlebells, medical balls, dumbbells, rods, picking levers, paraphernalia, steppe platforms – these sporty accessories are an integral part of the Crossfit workout. In this way, trainees improve their overall physical shape. The workouts are highly intense, most often without breaks, thus training also the psychic endurance of the participants. Crossfit improves the condition of the body and develops skills in 10 spheres – cardiovascular, breathing and strength endurance, strength, flexibility, explosiveness, speed, coordination, agility, balance and precision.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587234810/crossfit-1500x791.jpg.jpg",
            };

            var fourthGroupTraining = new GroupTraining
            {
                Name = "Fit ball",
                Description = "The Fit ball workout offers a new and different way of training. It combines elements of yoga and pilates. Fit ball contributes to increasing the strength and the endurance. This workout will help you improve your coordination, balance and posture. Studies have shown a significant increase in the respiratory system activity, the maximum oxygen consumption and the aerobic endurance. This method also has a positive effect on the spinal motility as well as the elasticity of the muscles and the joints, leading to the removal or the reduction of joint pain. Using various fit ball exercises, you can tighten the glute muscles, the hips and abdomen.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587411627/IMG_0206-1200x800.jpg.jpg",
            };

            var fifthGroupTraining = new GroupTraining
            {
                Name = "TapOut",
                Description = "TapOut is an intense cardio program combining elements of martial arts and strength exercises. The basis of TapOut is the techniques applied in mixed martial arts (MMA). Participants in this group practice use both kicks and fists, as well as kicks with elbows and elbows to enhance body coordination and burn a huge amount of calories. In doing so, practitoners perform cardio exercises typical of the training of real MMA fighters. These include rope jumping, weight-lifting, push-ups and plyometric exercises designed to achieve maximum muscle load for a short period of time. The latter include jumping, bumping, throwing and catching a medical ball, etc. TapOut is an extremely effective workout that will change your shape in just 90 days.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587411686/tapout.jpg.jpg",
            };

            var sixsthGroupTraining = new GroupTraining
            {
                Name = "Pilates",
                Description = "Pilates is a gymnastic program combining elements of calanetics, ballet and yoga. The exercises are performed on the ground on a mat, on the background of relaxing music. Additional equipment includes various devices such as balls, bands, springs, hoops and dumbbells. They serve to disturb the equilibrium and cause the muscles responsible for stabilizing the body to be shortened, increasing flexibility and endurance. Unlike most group activities, each exercise has three levels of difficulty (beginner, advanced, and expert) and is performed only once within a certain number of iterations instead of series. All movements are performed smoothly and slowly and overflowing one another. The goal of this group exercise, besides stretching and making muscles more flexible, is to achieve natural body grace and to put emphasis on breathing and concentration on thoughts.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587411757/the-beginners-guide-to-pilates.jpeg.jpg",
            };

            var seventhGroupTraining = new GroupTraining
            {
                Name = "Zumba",
                Description = "Zumba is a cardio program based on Latin dance. During one workout, aerobic movements are performed against the background of alternating fast and slow musical rhythms. Endurance is trained and the work is targeted to load all muscle groups – from calf to shoulder. Zumba includes in its choreography various movements from aerobics and many dance styles of South American culture – cha-cha, salsa, merengue, reggaeton, flamenco and more. One of the benefits of this group activity is that no physical training or dance technique is required. Zumba is suitable for melting excess fat and accumulated during the day calories. It tones the entire body, increases flexibility and strengthens metabolism.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587412041/unnamed.jpg.jpg",
            };

            var eightGroupTraining = new GroupTraining
            {
                Name = "Aerobics",
                Description = "Aerobics is a combined cardio program for endurance, tonus and balanced musculature. The aerobics exercises are conducted by professional instructors who regulate the intensity of the series and individual exercises with the assistance of dynamic music. The fast aerobic musical accompaniment is one of its most emblematic, and it's no accidentally. Initially, aerobics is conceived as an exercise that improves the condition of the respiratory and cardiovascular system, but with long practice, this type of cardio workout also increases the strength, flexibility and coordination of the body. Aerobics is particularly effective for the development of muscles in the lower body and torso, and the high intensity of the movements distinguishes it as one of the most popular methods of weight loss and calorie burning.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587412122/25781016-full-length-of-instructor-with-fitness-class-performing-step-aerobics-exercise-in-gym.jpg.jpg",
            };

            var ninthGroupTraining = new GroupTraining
            {
                Name = "Kick Box",
                Description = "Boxing and kickboxing workouts are intense cardio exercises that train strength and coordination. Contrary to understanding, boxing loads all muscle groups – not just the upper but also the lower part of the body. This is because boxing is just as important as hand punches. Group boxing and kickboxing activities include boxing a punching bag, shadow boxing, rope jumping, and double boxing bag punches. For those of you who want to improve their technique, Pulse provides the opportunity for individual lessons that increase the difficulty by increasing the workload and adding sparring at a professional boxing ring.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587412212/248305-699x450-kickboxing-moves-list.jpg.jpg",
            };

            await dbContext.GroupTrainings.AddAsync(firstGroupTraining);
            await dbContext.GroupTrainings.AddAsync(secondGroupTraining);
            await dbContext.GroupTrainings.AddAsync(thirdGroupTraining);
            await dbContext.GroupTrainings.AddAsync(fourthGroupTraining);
            await dbContext.GroupTrainings.AddAsync(fifthGroupTraining);
            await dbContext.GroupTrainings.AddAsync(sixsthGroupTraining);
            await dbContext.GroupTrainings.AddAsync(seventhGroupTraining);
            await dbContext.GroupTrainings.AddAsync(eightGroupTraining);
            await dbContext.GroupTrainings.AddAsync(ninthGroupTraining);

            await dbContext.SaveChangesAsync();
        }
    }
}
