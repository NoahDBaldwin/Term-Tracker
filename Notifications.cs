using C971.Models;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971
{
    public class Notifications
    {

        // Send Notifications for a course, cancel if false passed
        public static async Task EnableCourseNotifications(Course course, bool result)
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }

            var request1 = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Course Reminder",
                Subtitle = course.Name,
                Description = $"{course.Name} starts on {course.Start.Month}/{course.Start.Day}/{course.Start.Year}, " +
                $"and ends on {course.End.Month}/{course.End.Day}/{course.End.Year}.",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(10),
                }
            };

            // Notification of start date one day before
            var request2 = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Course Start Reminder",
                Subtitle = course.Name,
                Description = $"{course.Name} starts on {course.Start.Month}/{course.Start.Day}/{course.Start.Year}.",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = course.Start.AddDays(-1),
                }
            };

            // Notification of End date one day before
            var request3 = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Course End Reminder",
                Subtitle = course.Name,
                Description = $"{course.Name} ends on {course.End.Month}/{course.End.Day}/{course.End.Year}.",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = course.Start.AddDays(-1),
                }
            };


            if (result)
            {
                await LocalNotificationCenter.Current.Show(request1);
                await LocalNotificationCenter.Current.Show(request2);
                await LocalNotificationCenter.Current.Show(request3);
            }
            else
            {
                LocalNotificationCenter.Current.Clear();
            }


        }





        //Send notifications for an assessment, cancel if false passed.
        public static async Task EnableAssessmentNotifications(Assessment assessment, bool result)
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }

            // Immediate Notify
            var request1 = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Course Reminder",
                Subtitle = assessment.Name,
                Description = $"{assessment.Name} starts on {assessment.Start.Month}/{assessment.Start.Day}/{assessment.Start.Year}, " +
                $"and ends on {assessment.End.Month}/{assessment.End.Day}/{assessment.End.Year}.",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                }
            };

            // Notification of start date one day before
            var request2 = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Assessment Start Reminder",
                Subtitle = assessment.Name,
                Description = $"{assessment.Name} starts on {assessment.Start.Month}/{assessment.Start.Day}/{assessment.Start.Year}.",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = assessment.Start.AddDays(-1),
                }
            };

            // Notification of End date one day before
            var request3 = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Assessment End Reminder",
                Subtitle = assessment.Name,
                Description = $"{assessment.Name} ends on {assessment.End.Month}/{assessment.End.Day}/{assessment.End.Year}.",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = assessment.Start.AddDays(-1),
                }
            };
            

            if (result)
            {
                await LocalNotificationCenter.Current.Show(request1);
                await LocalNotificationCenter.Current.Show(request2);
                await LocalNotificationCenter.Current.Show(request3);
            }
            else
            {
                LocalNotificationCenter.Current.Clear();
            }         
        }



    }
}
