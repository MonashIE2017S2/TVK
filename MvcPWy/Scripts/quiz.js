/* Created by yang and roshan
*  Date : 06-Sep-2017
*  Logic of the questionnaire is handled
* 
*/


Survey.Survey.cssType = "bootstrap";
Survey.defaultBootstrapCss.navigationButton = "btn btn-green";
// Initialize Firebase database 
var config = {
    apiKey: "AIzaSyBuZ3aZJOwa4Xwa3iJuLZe6WH0umz-brlc",
    authDomain: "thesecondhomedb.firebaseapp.com",
    databaseURL: "https://thesecondhomedb.firebaseio.com",
    projectId: "thesecondhomedb",
    storageBucket: "thesecondhomedb.appspot.com",
    messagingSenderId: "1047254460760"
};
firebase.initializeApp(config);

var keys=[];

var database = firebase.database();


database.ref().on("value", function (snap) {
//pull entries from database
    var obj = snap.val();
    for (x in obj) {
        keys.push(x);
    }
    window.survey = new Survey.Model({
        questions: [
            {
                type: "radiogroup", name: "StudyEngagement1", title: "What is the school attendance like for this child?", isRequired: true,
                colCount: 6, choices: ["Excellent(95%)", "Good(85%)", "Fair(75%)", "Not Good(60% or below)"]
            },
            {
                type: "radiogroup", name: "StudyEngagement2", title: "What is the overall grade or academic status for this child?", isRequired: true,
                colCount: 6, choices: ["Excellent(TOP 15%)", "Good(TOP 30%)", "Fair(TOP 60%)", "Not Good(Below 60%)"]
            },
            {
                type: "radiogroup", name: "Personality1", title: "Does this child have a record of significant bad behavior?(eg.violence)", isRequired: true,
                colCount: 6, choices: ["Many records", "Just one", "Never"]
            },
            {
                type: "dropdown", name: "Personality2", title: "How many friends does this child have?", isRequired: true, colCount: 0,
                choices: ["Few Friend", "One or Two Friends", "Many Friends"]
            },
            {
                type: "radiogroup", name: "SocialFactor1", title: "What is the gender of this child?", isRequired: true,
                colCount: 6, choices: ["Male","Female"]
            },
            {
                type: "dropdown", name: "SocialFactor2", title: "Please select the suburb where the child live in.", isRequired: true, colCount: 0,
                choices: keys
            },
            {
                type: "radiogroup", name: "SchoolFactor1", title: "Please select the area where your school is located.", isRequired: true, colCount: 6,
                choices: ["North-Eastern Victoria", "North-Western Victoria","South-Eastern Victoria","South-Western Victoria"]
            },
            {
                type: "radiogroup", name: "SchoolFactor2", title: "What type of school are you work in?", isRequired: true,
                colCount: 6, choices: ["Government", "Non-Government","Catholic","Indepentent"]
            },
            {
                type: "radiogroup", name: "FamilyFactor1", title: "Have you ever found any sign of domestic violence in the body of this child?", isRequired: true, colCount: 6,
                choices: ["Yes", "No"]
            },
            {
                type: "radiogroup", name: "FamilyFactor2", title: "What is the family status of this child?", isRequired: true, colCount: 6,
                choices: ["Single-Parent(With Mother)", "Single-Parent(With Father)", "Blend Family(Step mother or step father)","Two-parent Family", "Foster Family"]
            }
        ]
    });

/*    survey.onValueChanged.add(function(sender, options) {
        var erApi = "https://localhost:44306/api/IdentifyQuestions";
        $.getJSON(erApi,
            function(result) {
                $.each(result, function (i, field) { document.querySelector('#surveyEvidence').innerHTML = i + " " + field; });
            });
    });

    survey.onComplete.add(function (result) {
        document.querySelector('#surveyEvidence').innerHTML = "result: " + JSON.stringify(result.data);
    });*/

    survey.onValueChanged.add(function (sender, options) {
        var erApi = "/api/IdentifyQuestions/";

        switch (options.value) {
            //question1
            case "Excellent(95%)":
                erApi += "4";
                break;
            case "Good(85%)":
                erApi += "3";
                break;
            case "Fair(75%)":
                erApi += "2";
                break;
            case "Not Good(60% or below)":
                erApi += "1";
                break;
            //question2
            case "Excellent(TOP 15%)":
                erApi += "8";
                break;
            case "Good(TOP 30%)":
                erApi += "7";
                break;
            case "Fair(TOP 60%)":
                erApi += "6";
                break;
            case "Not Good(Below 60%)":
                erApi += "5";
                break;
            //question3
            case "Many records":
                erApi += "9";
                break;
            case "Just one":
                erApi += "10";
                break;
            case "Never":
                erApi += "11";
                break;
            //question4
            case "Few Friend":
                erApi += "12";
                break;
            case "One or Two Friends":
                erApi += "13";
                break;
            case "Many Friends":
                erApi += "13";
                break;
            //question5
            case "Male":
                erApi += "23";
                break;
            case "Female":
                erApi += "23";
                break;
            //question7
            case "North-Eastern Victoria":
                erApi += "22";
                break;
            case "North-Western Victoria":
                erApi += "22";
                break;
            case "South-Eastern Victoria":
                erApi += "22";
                break;
            case "South-Western Victoria":
                erApi += "22";
                break;
            //question8
            case "Government":
                erApi += "21";
                break;
            case "Non-Government":
                erApi += "21";
                break;
            case "Catholic":
                erApi += "21";
                break;
            case "Indepentent":
                erApi += "21";
                break;
            //question9
            case "Yes":
                erApi += "14";
                break;
            case "No":
                erApi += "15";
                break;
            //question 10
            case "Single-Parent(With Mother)":
                erApi += "16";
                break;
            case "Single-Parent(With Father)":
                erApi += "17";
                break;
            case "Blend Family(Step mother or step father)":
                erApi += "18";
                break;
            case "Two-parent Family":
                erApi += "20";
                break;
            case "Foster Family":
                erApi += "19";
                break;
        default:
            erApi += "24";
        }

        $.getJSON(erApi, {
                format: "json"
            })
            .done(function (data) {
                document.querySelector('#surveyEvidence').innerHTML = data.evidence;
                document.querySelector('#surveyReference').innerHTML = data.reference;
            });
    });

/*    survey.onComplete.add(function (result) {
        document.querySelector('#surveyEvidence').innerHTML = "result: " + JSON.stringify(result.data);
    });*/

    survey.onComplete.add(function (result) {

        var $resultPanelPage = $("#ResultPanel");
        var $surveyPage = $("#SurveyPanel");
        var $evidencePage = $("#EvidencePanel");
        var $referencePage = $("#ReferencePanel");
/*
        var $surveyPage = $("#SurveyPanel");
*/
/*
        $resultPage.show();
*/
        $resultPanelPage.show();
        $surveyPage.hide();
        $evidencePage.hide();
        $referencePage.hide();

        var ctx = document.getElementById("radarChartResult2").getContext('2d');
        Chart.defaults.global.defaultFontFamily = "Lato";
        Chart.defaults.global.defaultFontSize = 12;

        var chartValue = [10, 10, 10, 10, 10];
        var studyEngagementValue;
        var personalityValue;
        var socialFactorValue;
        var schoolFactorValue;
        var familyFactorValue;

        //StudyEngagement
        var studyEngagement1 = result.data['StudyEngagement1'];
        switch (studyEngagement1) {
            case "Excellent(95%)":
                studyEngagementValue = 90;
                break;
            case "Good(85%)":
                studyEngagementValue = 80;
                break;
            case "Fair(75%)":
                studyEngagementValue = 70;
                break;
            case "Not Good(60% or below)":
                studyEngagementValue = 60;
                break;
            default:
                studyEngagementValue = 0;
        }

        var studyEngagement2 = result.data['StudyEngagement2'];
        switch (studyEngagement2) {
        case "Excellent(TOP 15%)":
            studyEngagementValue += 10;
            break;
        case "Good(TOP 30%)":
            studyEngagementValue += 5;
            break;
        case "Fair(TOP 60%)":
            studyEngagementValue -= 10;
            break;
        case "Not Good(Below 60%)":
            studyEngagementValue -= 20;
            break;
        default:
            studyEngagementValue = 0;
        }
        chartValue[0] = studyEngagementValue;

        //Personality ["Many records", "Just one", "Never"]["Few Friend", "One or Two Friends", "Many Friends"]
        var personality1 = result.data['Personality1'];
        switch (personality1) {
        case "Many records":
            personalityValue = 40;
            break;
        case "Just one":
            personalityValue = 60;
            break;
        case "Never":
            personalityValue = 80;
            break;
        default:
            personalityValue = 0;
        }

        var personality2 = result.data["Personality2"];
        switch (personality2) {
        case "Few Friend":
            personalityValue -= 15;
            break;
        case "One or Two Friends":
            personalityValue -= 5;
            break;
        case "Many Friends":
            personalityValue += 10;
            break;
        default:
            personalityValue = 0;
        }
        chartValue[1] = personalityValue;

        //SocialFactor
        var ratioList = [];
        var maxRatio = 0;
        var minRatio = 200;
        snap.forEach(function (item) {
            var itemVal = item.val();
            var ratio = itemVal.TotalCount / itemVal.nillIncomeCount;
            ratioList.push(ratio);
            if (ratio > maxRatio) {
                maxRatio = ratio;
            }
            var ratio2 = itemVal.TotalCount / itemVal.nillIncomeCount;
            if (ratio2 < minRatio) {
                minRatio = ratio2;
            }
        });
        console.log(ratioList.sort(function (a, b) { return a - b }));
        console.log(maxRatio);
        console.log(minRatio);

        var socialFactor2 = result.data["SocialFactor2"];
        var nillIncomePercent = obj[socialFactor2]["TotalCount"] / obj[socialFactor2]["nillIncomeCount"];
        console.log(nillIncomePercent);

        if ( nillIncomePercent < 5.0){
            socialFactorValue = 25;
        } else if (nillIncomePercent < 8.0) {
            socialFactorValue = 50;
        } else if (nillIncomePercent < 9.0) {
            socialFactorValue = 62.5;
        } else if (nillIncomePercent < 9.6) {
            socialFactorValue = 65;
        } else if (nillIncomePercent < 10.0) {
            socialFactorValue = 67.5;
        } else if (nillIncomePercent < 10.4) {
            socialFactorValue = 70;
        } else if (nillIncomePercent < 11.5) {
            socialFactorValue = 72.5;
        } else if (nillIncomePercent < 12.5) {
            socialFactorValue = 75;
        } else if (nillIncomePercent < 13.5) {
            socialFactorValue = 77.5;
        } else if (nillIncomePercent < 14.5) {
            socialFactorValue = 80;
        } else if (nillIncomePercent < 16.0) {
            socialFactorValue = 85;
        } else if (nillIncomePercent < 17.0) {
            socialFactorValue = 90;
        } else {
            socialFactorValue = 95;
        }
        console.log(socialFactorValue);

        var socialFactor1 = result.data["SocialFactor1"];
        switch (socialFactor1) {
        case "Male":
            socialFactorValue -= 5 ;
            break;
        case "Female":
            socialFactorValue -= 0;
            break;
        default:
            socialFactorValue = 0;
        }
        
        chartValue[4] = socialFactorValue;

        //SchoolFactor ["North-Eastern Victoria", "North-Western Victoria","South-Eastern Victoria","South-Western Victoria"]
        //["Government", "Non-Government","Catholic","Indepentent"]
        var schoolFactor1 = result.data["SchoolFactor1"];
        var schoolFactor2 = result.data["SchoolFactor2"];
        console.log(schoolFactor1);
        console.log(schoolFactor2);
        switch (schoolFactor1) {
            case "North-Eastern Victoria":
                schoolFactorValue = 70;
                break;
            case "North-Western Victoria":
                schoolFactorValue = 80;
                break;
            case "South-Eastern Victoria":
                schoolFactorValue = 65;
                break;
            case "South-Western Victoria":
                schoolFactorValue = 60;
                break;
            default:
                schoolFactorValue = 0;
        }

        switch (schoolFactor2) {
            case "Government":
                schoolFactorValue += 0;
                break;
            case "Non-Government":
                schoolFactorValue -= 5;
                break;
            case "Catholic":
                schoolFactorValue -= 10;
                break;
            case "Indepentent":
                schoolFactorValue += 5;
                break;
            default:
                schoolFactorValue += 0;
        }
        console.log(schoolFactorValue);
        chartValue[2] = schoolFactorValue;

        //FamilyFactor ["Single-Parent(With Mother)", "Single-Parent(With Father)", "Blend Family(Step mother or step father)","Two-parent Family", "Foster Family"]

        var familyFactor1 = result.data["FamilyFactor1"];
        var familyFactor2 = result.data["FamilyFactor2"];
       
        switch (familyFactor2) {
            case "Single-Parent(With Mother)":
                familyFactorValue = 85;
                break;
            case "Single-Parent(With Father)":
                familyFactorValue = 80;
                break;
            case "Blend Family(Step mother or step father)":
                familyFactorValue = 75;
                break;
            case "Two-parent Family":
                familyFactorValue = 90;
                break;
            case "Foster Family":
                familyFactorValue = 70;
                break;
        default:
            familyFactorValue = 0;
        }

        switch (familyFactor1) {
        case "Yes":
            familyFactorValue -= 35;
            break;
        case "No":
            familyFactorValue -= 0;
            break;
        default:
            familyFactorValue += 0;
        }
        console.log(familyFactorValue);
        chartValue[3] = familyFactorValue;

        var marksData = {
            labels: [
                "Study Engagement", "Personality", "School-related factor", "Family-related factor", "Socio-cultural"
            ],
            datasets: [
                {
                    label: "The child you identified",
                    backgroundColor: "rgba(220,0,0,0.4)",
                    data: chartValue
    }
            ]
        };
        var optionsRadar = {
            scale: {
                ticks: {
                    beginAtZero: true,
                    max:100
                },
                pointLabels: {
                    fontSize: 12
                }
            }
        };
        var radarChart = new Chart(ctx,
            {
                type: 'radar',
                data: marksData,
                options: optionsRadar
            });

        var generalReport = "";

/*        var studyEngagementValue;
        var personalityValue;
        var socialFactorValue;
        var schoolFactorValue;
        var familyFactorValue;*/

        //Weakness Identification
        if (studyEngagementValue < 60) {
            generalReport +=
                "<br>The academic status of this child should be taken into consideration, the teacher should explore the root causes of this situation.";
        }

        if ((personalityValue < 60)) {
            generalReport += "<br>There is a record of bad behaviour about this child, and he/she probably facing human communication disorders. They both related to the family situation of this child. ";
        }

        if (socialFactorValue < 60) {
            generalReport +=
                "<br>Base on some statistics data, boys have more possiblity drop out from school than girls and the suburb where the child live in is a place with high proportion of nill-income people.";
        }

        if ((familyFactorValue < 60)) {
            generalReport += "<br>Living and growing in a warm family is very important for children, even in a two-parents family, domestic violence can leave this child to a homelessness.";
        }

        if ((schoolFactorValue < 60)) {
            generalReport += "<br>Base on some statistics data of victorian schools, the area of your school located is under average level and the type of your school have more dropout rate than the others.";
        }

        //5-aspects are Average
        if ((studyEngagementValue >= 60) && (personalityValue >= 60) &&
            (socialFactorValue >= 60) && (familyFactorValue >= 60) && (schoolFactorValue >= 60)) {
            generalReport = "<br>So far, all five signs of this child are in qualified status, but there are still potential risks on this child which shown by shortage in the diagram.";
            //5-aspects all good
            if ((studyEngagementValue >= 70) && (personalityValue >= 70) && (socialFactorValue >= 70) && (familyFactorValue >= 70) && (schoolFactorValue >= 70)) {
                generalReport = "<br>So far,so good, all five signs of are pointing to positive, so don't worry about this child.";
            }
        }

        document.getElementById("GeneralReport").innerHTML = generalReport;


        var schoolRelatedScore = document.getElementById("SchoolRelatedScore");
        var schoolRelatedScorePopOver = document.getElementById("SchoolRelatedPopOver");
        if (schoolFactorValue >= 60) {
            schoolRelatedScore.setAttribute("aria-valuenow", schoolFactorValue);
            schoolRelatedScorePopOver.setAttribute("title", schoolFactorValue + "/100,Pass");
        } else {
            schoolRelatedScore.setAttribute("style", "background-color: rgb(217,83,79);");
            schoolRelatedScore.setAttribute("aria-valuenow", schoolFactorValue);
            schoolRelatedScorePopOver.setAttribute("title", schoolFactorValue + "/100,Fail");
        }

        var familyRelatedScore = document.getElementById("FamilyRelatedScore");
        var familyRelatedScorePopOver = document.getElementById("FamilyRelatedPopOver");
        if (familyFactorValue >= 60) {
            familyRelatedScore.setAttribute("aria-valuenow", familyFactorValue);
            familyRelatedScorePopOver.setAttribute("title", familyFactorValue + "/100,Pass");
        } else {
            familyRelatedScore.setAttribute("style", "background-color: rgb(217,83,79);");
            familyRelatedScore.setAttribute("aria-valuenow", familyFactorValue);
            familyRelatedScorePopOver.setAttribute("title", familyFactorValue + "/100,Fail");
        }

        var socialRelatedScore = document.getElementById("SocialRelatedScore");
        var socialRelatedScorePopOver = document.getElementById("SocialRelatedPopOver");
        if (socialFactorValue >= 60) {
            socialRelatedScore.setAttribute("aria-valuenow", socialFactorValue);
            socialRelatedScorePopOver.setAttribute("title", socialFactorValue + "/100,Pass");
        } else {
            socialRelatedScore.setAttribute("style", "background-color: rgb(217,83,79);");
            socialRelatedScore.setAttribute("aria-valuenow", socialFactorValue);
            socialRelatedScorePopOver.setAttribute("title", socialFactorValue + "/100,Fail");
        }

        var personalityScore = document.getElementById("PersonalityScore");
        var personalityScorePopOver = document.getElementById("PersonalityPopOver");
        if (personalityValue >= 60) {
            personalityScore.setAttribute("aria-valuenow", personalityValue);
            personalityScorePopOver.setAttribute("title", personalityValue + "/100,Pass");
        } else {
            personalityScore.setAttribute("style", "background-color: rgb(217,83,79);");
            personalityScore.setAttribute("aria-valuenow", personalityValue);
            personalityScorePopOver.setAttribute("title", personalityValue + "/100,Fail");
        }

        var studyScore = document.getElementById("StudyEngagementScore");
        var studyScorePopOver = document.getElementById("StudyEngagementPopOver");
        if (studyEngagementValue >= 60) {
            studyScore.setAttribute("aria-valuenow", studyEngagementValue);
            studyScorePopOver.setAttribute("title", studyEngagementValue + "/100,Pass");
        } else {
            studyScore.setAttribute("style", "background-color: rgb(217,83,79);");
            studyScore.setAttribute("aria-valuenow", studyEngagementValue);
            studyScorePopOver.setAttribute("title", studyEngagementValue + "/100,Fail");
        }


        $('[data-toggle="tooltip"]').tooltip({ trigger: 'manual' }).tooltip('show');
        $(".progress-bar").each(function () {
            each_bar_width = $(this).attr('aria-valuenow');
            $(this).width(each_bar_width + '%');
        });
    });

    $("#surveyElement").Survey({ model: survey });
});
