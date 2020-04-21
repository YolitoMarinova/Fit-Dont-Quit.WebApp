namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;

    public class ArticlesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var firstUser = dbContext.Users.FirstOrDefault(u => u.UserName == "Yolito");
            var secondUser = dbContext.Users.FirstOrDefault(u => u.UserName == "Gochko91");

            if (dbContext.Articles.Any())
            {
                return;
            }

            var firstArticle = new Article
            {
                Title = "HOW LONG SHOULD YOU REALLY HOLD THE PLANK EXERCISE TO SEE BENEFITS ?",
                Content = "Okay, everyone…the magic number when it comes to how long you should hold the plank exercise is…it depends! " +
            "Disappointed that I didn’t have a more straightforward answer? Well, let me explain: it depends on why you’re doing the plank in the first place. " +
            "Planks are such an amazing core exercise and can be super beneficial when performed correctly. Not sure you’ve got the form down? " +
            "Here’s how to do the perfect plank. 3 WAYS TO INCORPORATE THE PLANK EXERCISE FOR MAXIMUM BENEFITS! 1.DO A PLANK CHALLENGE Your competition ? " +
            "Yourself! This is where you hold a plank for as long as you can and time it.It doesn’t matter if you’re doing a high plank or a low plank — " +
            "just make sure you are practicing proper form. Monitor your progress each week — even 1 second longer is improvement! " +
            "How long should you hold it: As long as you can! " +
            "2.PLANK AS PART OF YOUR WARM - UP Doing a plank to warm up your core before a workout is a good idea. " +
            "However, you don’t want to completely exhaust your core as it needs to be strong and ready to support other movements during your workout. " +
            "In this case, I really like exercises like Plank to Downward Dog, Inchworms, High Plank &Low Plank done for shorter durations and repetitions. " +
            "All the exercises mentioned can be found in the adidas Training app with step - by - step instructional videos. " +
            "How long should you hold it: 10 - 30 secs or 5 - 10 reps, for 1 - 3 rounds. 3.PLANK AS PART OF YOUR WORKOUT" +
            " You don’t have to wait for “abs day” in order to incorporate planks into your workout routine.Static planks, " +
            "as well as dynamic plank variations, fit perfectly into a total - body circuit training workout(like those found in the Workout Creator feature) " +
            ".Be sure to track your progress.You’ll get to know your body, and soon a 30 - second plank won’t be as tough as it once was, " +
            "or you’ll be able to perform more High Plank Shoulder Taps without taking a break. How long should you hold it: Push yourself here. " +
            "Of course, you don’t want to “max out” as you would during the plank challenge, but you want to have to work for it! " +
            "So as you can see…it really does depend when it comes to how long you should hold the plank exercise to see benefits. " +
            "Who cares if you can hold a plank for 5 minutes if your form is really bad. What really matters is that you are incorporating the plank and " +
            "plank-based exercises into your workout routine on a regular basis.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587470809/img/blog/blog-detail-hero_ato850.jpg",
                User = firstUser,
            };

            var secondArticle = new Article
            {
                Title = "WORKOUT CREATOR: BUILD YOUR OWN HOME WORKOUT",
                Content = "Want to train your arms for 15 minutes? How about a half-hour butt and abs workout you can easily do in the comfort of your own home? " +
            "You choose the muscle groups and the duration, and we will create the perfect bodyweight training workout for you in a matter of seconds – " +
            "no matter where your on - the - go lifestyle takes you! The Workout Creator in your adidas Training app makes fitting in a workout with the time you " +
            "have easy, sweaty and effective. WHERE CAN YOU FIND THE WORKOUT CREATOR ? To start the Workout Creator, " +
            "simply click on the Workouts tab in the adidas Training app menu.Scroll down until you find the Workout Creator. " +
            "Select the muscle groups you would like to focus on and choose the duration of your workout. " +
            "WHAT’S THE DIFFERENCE BETWEEN THE WORKOUT CREATOR AND TRAINING PLAN WORKOUTS ? " +
            "Unlike some of the Training Plan workouts in the adidas Training app, the exercises in the Workout Creator challenge you to do as many repetitions " +
            "as you can during a set amount of time(as opposed to a set amount of repetitions).This creates a more HIIT-style or circuit training style workout, " +
            "challenging your muscles while also elevating your heart rate. With all adidas Training app workouts, you will mostly be doing bodyweight exercises. " +
            "You can use the Workout Creator on its own on a regular basis, use it in between workouts in your Training Plan if you want to target a muscle group " +
            "that’s not already sore, or fit in a quick workout after a nice run – do as you please! Additionally, the Workout Creator can act as a form of cross - " +
            "training to support the activity you’re trying to improve. For example, if you’re a runner and want stronger abs or stronger arms to improve your running, " +
            "go for an abs or upper body workout(or both!).The Workout Creator can really fit into anyone’s workout routine. " +
            "And one more thing, you can now pause any workout in the adidas Training app in case something unexpected comes up, like you get a phone call. " +
            "HOW LONG DO THE WORKOUT CREATOR WORKOUTS TAKE ?" +
            " It’s totally up to you! You can decide on the exact time you want to work out (between 7 - 45 minutes) plus the targeted muscle groups: " +
            "Upper Body, Arms, Abs &Core, Legs, Butt or Full Body. You can select more than one category(i.e.Arms, Abs & Butt) or select Full Body. " +
            "When you’re finished selecting your duration and muscle groups, press “Continue” and you’re ready to rock! " +
            "IS THE WORKOUT CREATOR SUITABLE FOR ALL FITNESS LEVELS? " +
            "Absolutely! If you’re a beginner, start out with a workout that’s around 7 - 10 minutes to see how you feel. " +
            "As you get fitter and stronger, you’ll be able to increase the duration of your workouts. " +
            "And don’t get carried away in the beginning and do a workout every single day because you’re super-motivated.Start out with 2 - 3 days per week " +
            "and then go from there. HOW LONG DOES IT TAKE TO SEE RESULTS WITH THE WORKOUT CREATOR?" +
            " Keep in mind that everyone is different, and diet plays a huge role in getting into shape! " +
            "You can find everything you need to know about what to eat before and after your workout on the adidas Runtastic blog. " +
            "So what do you say? Download the adidas Training app to give the Workout Creator a go and stay in shape!",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587470808/img/blog/blog-6_rfadkm.jpg",
                User = firstUser,
            };

            var thirdArticle = new Article
            {
                Title = "Our Top 3 Tips For Setting Goals, And Reaching Them, Before New Years",
                Content = "If you’re putting off your goals in anticipation of a new year, you may want to ask yourself why you’re waiting until New Years " +
                "to make a lifestyle change. Is the date motivating to you? The truth is, other than gyms offering specials on memberships, " +
                "there isn’t a worthy difference between any other date and January 1st. You don’t have to make a goal at the new year just because it is " +
                "a popular time to do so. You can do that any time, so why wait? Start now, reach your goals faster! " +
                "The “I’ll start working out on Monday” plan doesn’t have a very high success rate.With this plan, you are already procrastinating. " +
                "If you can wait until Monday or the new year to start, you can easily push that out to the next Monday or the next month and before you know it," +
                " you’re doing the same thing the following new year. " +
                "The “Today I’m making a change” plan will get you where you want to be. " +
                "Write down your goals and what steps you need to make to achieve them.Make a realistic timeline, what you might need help with," +
                " and the support system you will use to get you there.If you need assistance on where to start or help with goal setting, find a coach! " +
                "A coach will do everything in their power to make sure you are staying on track and achieving everything you set your mind do. " +
                "Find your why. It is so important to attach emotion and urgency to your goals. " +
                "Find what will make you motivated to do what you set out for and keep doing it even when it’s challenging and you want to quit. " +
                "Some examples of this are: You need to set a good example for your children, they need to grow up with a healthy influence in their lives. " +
                "Heart disease runs in your family, you do this so you can live a long and healthy life. " +
                "Your doctor tells you that you are at risk for certain illnesses or diseases if you don’t make a change. " +
                "Fitness is freedom.If you are fit, you can do the things you want to do when you want to do them without limitation or pain. " +
                "Just to feel confident and comfortable in your own skin.Being strong is empowering! " +
                "Unless January 1st holds a special place in your heart, your WHY doesn’t have a date attached to it.You need to start today. " +
                "Determine if roadblocks are legitimate vs an excuse? " +
                "Time during the holiday season is a common excuse for why people want to wait until January to start their goals. " +
                "Time will always be a limiting factor in our lives and yes, the holiday season can be especially difficult to start a new exercise routine " +
                "and make major changes.What if you didn’t add more things at this time but could still make progress. " +
                "What if you just changed the way you did some things? Simple things that won’t be stressful during the holiday season like parking further away " +
                "when you go to the grocery store, substituting vegetables for potato chips, or instead of watching TV, you go for a walk. It’s a good start " +
                "in the right direction! Excuses are easy to make.If you go back to your why, the excuses seem pretty easy to overcome. " +
                "If your why is to set a good example for your children, it doesn’t sound very good to say you don’t have time to set a good example for your kids. " +
                "If your excuse is that a gym membership is too expensive, but your why is that you are at risk for certain illness or diseases, " +
                "you will probably be spending a lot more on medical bills in the future than a gym membership.Your why is more important than any excuse. " +
                "There are legitimate reasons why you can’t start on your goals today, such as waiting for doctor clearance to exercise, illness, etc. " +
                "However, even if you are waiting on clearance to exercise or need to wait a certain period of time before you can move more, you can still " +
                "take time for goal setting, making healthy dietary decisions, and taking steps towards a healthier lifestyle. " +
                "Regardless if you are waiting for a certain date to start your goals, you should be proud of yourself for making the steps to become a better you. " +
                "Thinking about where you want to be is the first step, now let’s turn that inertia into momentum!",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587470808/img/blog/blog-7_guudvz.jpg",
                User = secondUser,
            };

            var fourthArticle = new Article
            {
                Title = "When Fitness Fights Breast Cancer: 7 Inspiring Stories",
                Content = "Lisa N. from Canton, OH It was time when… “I couldn’t fit in all my clothes.” " +
            "“I joined Anytime Fitness several years ago.I managed to get to a great weight and felt healthy.Unfortunately in July of 2014 " +
            "I was diagnosed with breast cancer and underwent a double mastectomy with reconstruction as well as chemotherapy.Throughout this time " +
            "I continued to go to the gym at least 3x a week just to keep my spirits up and keep me sane.The staff and my workout buddies were incredibly supportive and " +
            "I couldn’t have made it through my treatment without this one constant in my life.I am now cancer free and my daughter and I are working with a trainer. " +
            "This makes us feel terrific.” Wendy B.from North Branch, MN Wendy breast cancer survivorIt was time when… " +
            "“I hit my all time high weight 16 years after my youngest was born.” I was diagnosed with breast cancer one month after finding my favorite Zumba class " +
            "in North Branch.Luckily I needed a partial masectomy and radiation so I only missed a month of classes.My coach, Kathy McClosky, was so nice she checked in " +
            "on me during that time away.She is so sweet and really cares.I have two more surgeries, hysterctomy and bi-lateral mastectomy due to genetic " +
            "hereditary cancer.But love that I am in good shape to endure the surgery!” Terry F breast cancer supporter Terry F.from Groton, MA " +
            "It was time when… “My wife came home with the news that she had breast cancer. I had to be there for her.”" +
            "“I had gone to schedule bariatric surgery, and started to diet for that.I started to lose a few pounds, and I remembered that underneath the pounds was" +
            " the rugby player I was for 20 years.I started to eat better, but working out alone I wasn’t motivated. My son and I drive past the " +
            "Anytime Fitness in Groton, and he (13) said he would go with me there.So we went in, me feeling nervous(no big person wants to be seen at a gym). " +
            "The manager was awesome, and I felt right at home.Pounds started to drop.Now I can run for miles and am down 88 pounds.Anytime fitness is most of the reason " +
            "why.” Lisa P breast cancer survivor Lisa P.from Adel, GA " +
            "“I knew it was time when I needed to get my strength back and change my attitude.” " +
            "“I was diagnosed with stage 4 breast cancer in 2007, with 1&1/2 years of chemotherapy and 54 pounds heavier …. " +
            "I started walking and everything I could think of to not only for my physical appearance but mental health… December of 2013 a new Anytime Fitness came to " +
            "our small town and I was ecstatic … No one in my family was interested but me, so I joined knowing that I had to make a difference in my life… " +
            "I’m am 58 pounds lighter, so I dropped 4 extra pounds.. Yay, but the most important part is that I got my life back.” Kim D breast cancer survivor " +
            "Kim D.from Woodbury, MN " +
            "It was time when… “The lymphedema started acting up after my bilateral mastectomy from breast cancer.” " +
            "“Three different doctors told me exercise and losing weight were the best defense against lymphedema so " +
            "I joined and was doing great until my mom got sick in May.She passed away in June and I got married August 1 so it’s time to start back at it because" +
            " I can tell my arm and chest is swelling up again just from a short hiatus. From when I started to when life interrupted my workouts my lymphedema numbers" +
            " dropped dramatically to the point I didn’t have to see a physical therapist anymore!” Jessica S breast cancer survivor Jessica S.from Hermantown, MN " +
            "It was time when… “When I saw a body I’ve fought so hard to stay alive getting overweight.” " +
            "“I decided to join because I have survived invasive breastfeeding cancer and overcame the physical rehab of a shattered pelvis and now " +
            "I need to keep this body that I have fought so hard to keep alive in top condition. If I don’t keep healthy and fit then all the battles " +
            "I fought before are for nothing.Life is a challenge and I am up for another victory!” Cheryl A. from Murrysville, PA " +
            "Cheryl breast cancer survivorIt was time when… “I started to gain weight while taking prescribed medication.” " +
            "“My husband and I decided to join Anytime Fitness to lose weight. I wanted to slim down for my wedding day along with getting fit. " +
            "Brian Wayman was my first trainer. Through Brian’s knowledge and understanding of my goals, I have been able to meet and exceed those goals. " +
            "His knowledge of nutrition was very instrumental in my getting my weight under control. Four years ago I was diagnosed with stage 1 Breast Cancer, " +
            "I had 2 Lumpectomy surgeries along with radiation and medication.My eating habits where out of control. " +
            "Joining Anytime Fitness has been so rewarding to me.I encourage everyone to join!!” Learn about breast cancer detection, support, and more at nationalbreastcancer.org.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587470807/img/blog/bd-2_mf6bcq.jpg",
                User = secondUser,
            };

            var fifthArticle = new Article
            {
                Title = "5 Healthy Ways To Celebrate Your Fitness Success",
                Content = "Setting goals for yourself is an important part of every fitness journey. " +
                "Whether you’ve achieved a number on the scale, a number on the weight bench or a number of miles run, keeping track of those big milestones is " +
                "crucial to staying motivated. But what’s the best way to treat yourself after achieving a milestone ? " +
                "We definitely do not recommend going out and ordering the biggest milkshake you can find!Instead, " +
                "below are some of our favorite(healthy) ways to celebrate your successes, both big and small. " +
                "Schedule A Spa Day " +
                "You’ve worked your muscles hard—now let them relax!A rejuvenating spa day is the perfect guilt - free way to treat yourself, and " +
                "will leave you refreshed and ready to crush your next goal! Don’t have time for an entire day ? Scheduling an extra - " +
                "long massage is a great way to meet in the middle of time constraints and indulgence, and will provide your muscles with the detox they need " +
                "to bounce back even faster for your next training session. " +
                "Take a(Healthy) Cooking Class " +
                "Normally we’re not big proponents of food - based rewards, but taking a cooking class have enough benefits that we think it’s OK! " +
                "Not only does the fun of cooking classes make them a reward on their own, but by picking a health-based one, you’ll be learning about curating " +
                "a proper nutrition plan for continued fitness success." +
                " Find Some New Workout Gear" +
                " What better excuse to buy new workout gear than celebrating your accomplishments in the gym? " +
                "While budget gear will certainly get the job done, there’s something about a nice pair of sneakers or leggings that just feels absolutely luxurious. " +
                "Looking great and feeling great is the best way to slay your next workout! " +
                "Clean Out Your Closet " +
                "This might sound like more of a chore than a reward, but bear with us.If you’ve hit a major weight-loss milestone, " +
                "chances are you have an excess of too-big clothes lying around. Take a day to pare down your wardrobe and donate those items you no " +
                "longer need—you’ll have less clutter and the confidence of knowing how far you’ve come! " +
                "Upgrade Your Music Game " +
                "Music is a big part of fitness motivation, so if you’ve been making do with the headphones that came with your phone, " +
                "now is the perfect excuse to upgrade! A sleek wireless pair will take you from the treadmill to the weight set without annoying cord tangles, " +
                "and you’ll be able to get even more engaged by your favorite pump-up jams. If you need advice on setting fitness goals or celebrating your successes, " +
                "Anytime Fitness is here to help! Visit one of our gyms today to talk with our helpful staff.",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1587470808/img/blog/blog-8_azibdd.jpg",
                User = firstUser,
            };

            await dbContext.Articles.AddAsync(firstArticle);
            await dbContext.Articles.AddAsync(secondArticle);
            await dbContext.Articles.AddAsync(thirdArticle);
            await dbContext.Articles.AddAsync(fourthArticle);
            await dbContext.Articles.AddAsync(fifthArticle);

            await dbContext.SaveChangesAsync();
        }
    }
}
