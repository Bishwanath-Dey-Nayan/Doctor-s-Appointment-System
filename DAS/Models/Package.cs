using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Models
{
    public class Package
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Package Name")]
        public string Name { get; set; }
        [Display(Name = "24/7 Doctor Consultation Over the Phone ")]
        public string consutation_over_phone { get; set; }
        [Display(Name = "Doctor Appointment Service ")]
        public string AppointmentService { get; set; }
        [Display(Name = "Proactive Counselling by a Doctor Over the Phone ")]
        public string counselling_over_phone { get; set; }
        [Display(Name = "Sample Collection & Report Delivery")]
        public string sample_collection_report_del { get; set; }
        [Display(Name = "Free Medicine Home Delivery")]
        public string free_medicine_del { get; set; }
        [Display(Name = "Medicine Intake Reminder Through SMS")]
        public string med_intake_reminder { get; set; }
        [Display(Name = "Pick & Drop for Doctor Visit and Tests")]
        public string pick_drop_doc_visit { get; set; }
        [Display(Name = "Emergency and Ambulance Service Information")]
        public string Emergency_ambulance_serv { get; set; }
        [Display(Name = "Hospitalization Cashback")]
        public string hospitalization_cashback { get; set; }
        [Display(Name = "Out Patient Cashback")]
        public string out_paitent_cashback { get; set; }
        [Display(Name = "Life Insurance Coverage")]
        public string Life_insurance { get; set; }
        [Display(Name = "Package Type")]
        public int pack_type { get; set; }
        public virtual PackType packtype { get; set; }
        [Display(Name = "Amount")]
        public double Amount { get; set; }



    }
}