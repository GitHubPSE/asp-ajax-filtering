using Microsoft.AspNetCore.Mvc;

namespace aspAjaxProject.Controllers
{
    public class LecturePreviewController : Controller
    {
        [HttpPost]
        public JsonResult GetList(string subject, string publisher, string teacher, string session,
            string video, string listType)
        {
            var allLectures = new List<Lecture>
            {
                new Lecture("L001", "코딩 기초", "프로그래밍", "김코딩", "1", "태양출판사"),
                new Lecture("L002", "코딩 실습", "프로그래밍", "박코딩", "2", "태양출판사"),
                new Lecture("L003", "웹개발 입문", "웹개발", "이웹", "1", "바다출판사"),
                new Lecture("L004", "웹개발 실전", "웹개발", "정웹", "2", "바다출판사"),
                new Lecture("L005", "웹디자인 기초", "웹디자인", "윤디자이너", "1", "하늘출판사"),
                new Lecture("L006", "웹디자인 실습", "웹디자인", "조디자이너", "2", "하늘출판사"),
                new Lecture("L007", "HTML 마스터", "웹개발", "김마크업", "1", "태양출판사"),
                new Lecture("L008", "HTML 실습", "웹개발", "박마크업", "2", "태양출판사"),
                new Lecture("L009", "CSS 디자인", "웹디자인", "최CSS", "1", "하늘출판사"),
                new Lecture("L010", "CSS 애니메이션", "웹디자인", "윤CSS", "2", "하늘출판사"),
                new Lecture("L011", "JavaScript 기본", "웹개발", "하JS", "1", "바다출판사"),
                new Lecture("L012", "JavaScript 실습", "웹개발", "윤JS", "2", "바다출판사"),
                new Lecture("L013", "React 입문", "프로그래밍", "강React", "1", "하늘출판사"),
                new Lecture("L014", "React 심화", "프로그래밍", "홍React", "2", "하늘출판사"),
                new Lecture("L015", "Node.js 시작", "프로그래밍", "김Node", "1", "태양출판사"),
                new Lecture("L016", "Node.js 활용", "프로그래밍", "이Node", "2", "태양출판사"),
                new Lecture("L017", "SQL 기초", "프로그래밍", "양SQL", "1", "바다출판사"),
                new Lecture("L018", "SQL 실전", "프로그래밍", "정SQL", "2", "바다출판사"),
                new Lecture("L019", "Git 사용법", "프로그래밍", "노Git", "1", "구름출판사"),
                new Lecture("L020", "버전관리 실습", "프로그래밍", "백Git", "2", "구름출판사"),
                new Lecture("L021", "코딩 프로젝트", "프로그래밍", "조코딩", "1", "태양출판사"),
                new Lecture("L022", "실전 웹개발", "웹개발", "류웹", "2", "바다출판사"),
                new Lecture("L023", "CSS 실습", "웹디자인", "한CSS", "1", "하늘출판사"),
                new Lecture("L024", "자바스크립트 예제", "웹개발", "임JS", "2", "바다출판사"),
                new Lecture("L025", "컴포넌트 설계", "프로그래밍", "장React", "1", "하늘출판사"),
                new Lecture("L026", "API 연동", "프로그래밍", "윤Node", "2", "태양출판사"),
                new Lecture("L027", "MySQL 실습", "프로그래밍", "김SQL", "1", "바다출판사"),
                new Lecture("L028", "GitHub 활용", "프로그래밍", "이Git", "2", "구름출판사"),
                new Lecture("L029", "디자인 패턴", "프로그래밍", "최코드", "1", "태양출판사"),
                new Lecture("L030", "리팩토링", "프로그래밍", "조개선", "2", "태양출판사")
            };

            var filtered = allLectures.AsQueryable();
            
            if (!string.IsNullOrEmpty(subject) && subject != "ALL")
            {
                var temp = new List<Lecture>();
                foreach (var item in filtered)
                {
                    if (item.SubjectCode == subject)
                    {
                        temp.Add(item);
                    }
                }
                filtered = temp.AsQueryable();
            }
            if (!string.IsNullOrEmpty(publisher) && publisher != "ALL")
            {
                var temp = new List<Lecture>();
                foreach (var item in filtered)
                {
                    if (item.Publisher == publisher)
                    {
                        temp.Add(item);
                    }
                }
                filtered = temp.AsQueryable();
            }
            if (!string.IsNullOrEmpty(teacher) && teacher != "ALL")
            {
                var temp = new List<Lecture>();
                foreach (var item in filtered)
                {
                    if (item.Teacher == teacher)
                    {
                        temp.Add(item);
                    }
                }
                filtered = temp.AsQueryable();
            }
            if (!string.IsNullOrEmpty(session) && session != "0")
            {
                var temp = new List<Lecture>();
                foreach (var item in filtered)
                {
                    if (item.Session == session)
                    {
                        temp.Add(item);
                    }
                }
                filtered = temp.AsQueryable();
            }
            if (!string.IsNullOrEmpty(video))
            {
                var temp = new List<Lecture>();
                foreach (var item in filtered)
                {
                    if (item.LectureCode == video)
                    {
                        temp.Add(item);
                    }
                }
                filtered = temp.AsQueryable();
            }

            List<object> result;

            switch (listType)
            {
                case "SUBJECT":
                    var subjectSet = new HashSet<string>();
                    var subjectList = new List<object>();
                    foreach (var item in filtered)
                    {
                        if (subjectSet.Add(item.SubjectCode))
                        {
                            subjectList.Add(new { Subject = item.SubjectCode });
                        }
                    }
                    result = subjectList;
                    break;
                case "PUBLISHER":
                    var publisherSet = new HashSet<string>();
                    var publisherList = new List<object>();
                    foreach (var item in filtered)
                    {
                        if (publisherSet.Add(item.Publisher))
                        {
                            publisherList.Add(new { Publisher = item.Publisher });
                        }
                    }
                    result = publisherList;
                    break;
                case "TEACHER":
                    var teacherSet = new HashSet<string>();
                    var teacherList = new List<object>();
                    foreach (var item in filtered)
                    {
                        if (teacherSet.Add(item.Teacher))
                        {
                            teacherList.Add(new { Teacher = item.Teacher });
                        }
                    }
                    result = teacherList;
                    break;
                case "SESSION":
                    var sessionSet = new HashSet<string>();
                    var sessionList = new List<object>();
                    foreach (var item in filtered)
                    {
                        if (sessionSet.Add(item.Session))
                        {
                            sessionList.Add(new { Session = item.Session });
                        }
                    }
                    result = sessionList;
                    break;
                case "LECTURE":
                default:
                    var lectureList = new List<object>();
                    int count = filtered.Count();
                    foreach (var x in filtered)
                    {
                        lectureList.Add(new
                        {
                            code = x.LectureCode,
                            lecture = x.LectureName,
                            subject = x.SubjectCode,
                            teacher = x.Teacher,
                            session = x.Session,
                            publisher = x.Publisher,
                            totalCount = count
                        });
                    }
                    result = lectureList;
                    break;
            }

            return Json(result);
        }

        public class Lecture
        {
            public Lecture(string code, string name, string subject, string teacher, string session,
                string publisher)
            {
                LectureCode = code;
                LectureName = name;
                SubjectCode = subject;
                Teacher = teacher;
                Session = session;
                Publisher = publisher;
            }

            public string LectureCode { get; set; }
            public string LectureName { get; set; }
            public string SubjectCode { get; set; }
            public string Teacher { get; set; }
            public string Session { get; set; }
            public string Publisher { get; set; }
        }

        public IActionResult CodingLecture()
        {
            return View();
        }
    }
}
