using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPregnancyTracker.Data.Models;

namespace MyPregnancyTracker.Data.Configuration
{
    internal class MyPregnancyTrackerTaskConfiguration : IEntityTypeConfiguration<MyPregnancyTrackerTask>
    {
        public void Configure(EntityTypeBuilder<MyPregnancyTrackerTask> builder)
        {
            builder.HasData(
                new MyPregnancyTrackerTask
                {
                    Id = 1,
                    Content = "Запишете датата на започване на менструалния цикъл и неговата продължителност.",
                    GestationalWeekId = 1,
                },
                new MyPregnancyTrackerTask
                {
                    Id = 2,
                    Content = "Свържете се със своя лекар или фармацевт, за да Ви препоръча фолиева киселина или мултивитаминен комплекс, за бременни, в подходяща дозировка.",
                    GestationalWeekId = 1
                },
                new MyPregnancyTrackerTask
                {
                    Id = 3,
                    Content = "Направете списък на лекарствата, които приемате или сте приемали в последните няколко месеца.Обсъдете списъка с лекаря си.",
                    GestationalWeekId = 1
                },
                new MyPregnancyTrackerTask
                {
                    Id = 4,
                    Content = "Изберете метод, по който ще следите за настъпването на овулация.В зависимост от избрания метод се снабдете с дигитален термометър, тестове за овулация или и двете.",
                    GestationalWeekId = 1
                },
                new MyPregnancyTrackerTask
                {
                    Id = 5,
                    Content = "Ако още не сте преустановили тютюнопушенето и употребата на алкохол и кофеин, направете го сега.",
                    GestationalWeekId = 1
                },
                new MyPregnancyTrackerTask
                {
                    Id = 6,
                    Content = "Следете за появата на овулация през тази гестационна седмица - увеличаване на цервикалната слуз и повишаване на базалната температура.",
                    GestationalWeekId = 2
                },
                new MyPregnancyTrackerTask
                {
                    Id = 7,
                    Content = "Планирайте седмичното си меню, като включите в него естествени източници на фолиева киселина.",
                    GestationalWeekId = 2
                },
                new MyPregnancyTrackerTask
                {
                    Id = 8,
                    Content = "Ако все още не приемате фолиева киселина, започнете приема.Тя е важна за развитието на нервната система на Вашето бебе.",
                    GestationalWeekId = 2
                },
                new MyPregnancyTrackerTask
                {
                    Id = 9,
                    Content = "Запишете своята медицинска информация и тази на партньора си.Включете всичко, за което се сещате.",
                    GestationalWeekId = 2
                },
                new MyPregnancyTrackerTask
                {
                    Id = 10,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 3
                },
                new MyPregnancyTrackerTask
                {
                    Id = 11,
                    Content = "Изтрийте тренировките от седмичния си график.Направете същото и с вечерните ангажименти, ако имате такива.",
                    GestationalWeekId = 3
                },
                new MyPregnancyTrackerTask
                {
                    Id = 12,
                    Content = "Ако много искате да разберете за бременността си възможно най-рано, проучете в коя близка лаборатория ще можете да направите кръвен тест за бременност след около седмица.",
                    GestationalWeekId = 3
                },
                new MyPregnancyTrackerTask
                {
                    Id = 13,
                    Content = "Прехвърлете на партньора си пазаруването, чистенето и останалите задължения, изискващи физическо натоварване.",
                    GestationalWeekId = 3
                },
                new MyPregnancyTrackerTask
                {
                    Id = 14,
                    Content = "Ако закъснението е налице, купете си тест за бременност.Спазвайте внимателно инструкциите за употреба.",
                    GestationalWeekId = 4
                },
                new MyPregnancyTrackerTask
                {
                    Id = 15,
                    Content = "Ако тестът Ви е положителен, свържете се с личния си лекар или с гинеколога си.Те ще Ви ориентират кога е най-подходящо да запишете час за първи ехографски преглед.Помолете ги за препоръка за подходящ витаминен препарат.",
                    GestationalWeekId = 4
                },
                new MyPregnancyTrackerTask
                {
                    Id = 16,
                    Content = "Преустановете употребата на цигари, алкохол и кофеин, ако вече не сте го направили.",
                    GestationalWeekId = 4
                },
                new MyPregnancyTrackerTask
                {
                    Id = 17,
                    Content = "Купете си мултивитаминен препарат за бременни или фолиева киселина и започнете да ги приемате в дозата, препоръчана от Вашия лекар.",
                    GestationalWeekId = 4
                },
                new MyPregnancyTrackerTask
                {
                    Id = 18,
                    Content = "Започнете списъка с въпроси към лекаря.Включете всичко, което Ви интересува.Ако все още не сте избрали акушер-гинеколог и Ви предстои посещение при личния лекар, с когото да обсъдите дали и при кого ще се включите в програмата \"Майчино здравеопазване\".",
                    GestationalWeekId = 5
                },
                new MyPregnancyTrackerTask
                {
                    Id = 19,
                    Content = "Разберете дали сте боледували от варицела и рубеола - попитайте родителите си или потърсете стар здравен картон.",
                    GestationalWeekId = 5
                },
                new MyPregnancyTrackerTask
                {
                    Id = 20,
                    Content = "Измерете теглото си и запишете резултата.Ще Ви подсещаме да мерите теглото си веднъж на две седмици.Тази информация ще е ценна и за Вашия лекар.",
                    GestationalWeekId = 5
                },
                new MyPregnancyTrackerTask
                {
                    Id = 21,
                    Content = "Помолете партньора да води и взима по-голямото дете от училище и детска градина.",
                    GestationalWeekId = 5
                },
                new MyPregnancyTrackerTask
                {
                    Id = 22,
                    Content = "Ако все още нямате насрочена среща с гинеколог за първи ехографски преглед, свържете се с избрания от Вас лекар и си запишете час.",
                    GestationalWeekId = 6
                },
                new MyPregnancyTrackerTask
                {
                    Id = 23,
                    Content = "Обсъдете с партньора и с други членове на домакинството кои задачи и задължения можете да им прехвърлите, за да прекарате една спокойна и ненатоварваща бременност.",
                    GestationalWeekId = 6
                },
                new MyPregnancyTrackerTask
                {
                    Id = 24,
                    Content = "Ако имате домашен любимец, насрочете му час за ветеринарен преглед.Ветеринарният лекар ще постави нужните ваксинации и ще направи външно и вътрешно обезпаразитяване на любимеца Ви.",
                    GestationalWeekId = 6
                },
                new MyPregnancyTrackerTask
                {
                    Id = 25,
                    Content = "Преосмислете обичайния си дневен режим така, че да си осигурите време за почивка и личен комфорт.",
                    GestationalWeekId = 6
                },
                new MyPregnancyTrackerTask
                {
                    Id = 26,
                    Content = "Изберете кабинет и лекар, при който искате да проведете първата фетална морфология.",
                    GestationalWeekId = 7
                },
                new MyPregnancyTrackerTask
                {
                    Id = 27,
                    Content = "Запишете час за фетална морфология.",
                    GestationalWeekId = 7
                },
                new MyPregnancyTrackerTask
                {
                    Id = 28,
                    Content = "Ако се чувствате уморена и податлива на вируси и други инфекции, консултирайте се с лекаря си за подходящ имуностимулант.Хомеопатичните средства са много подходящи за целта.",
                    GestationalWeekId = 7
                },
                new MyPregnancyTrackerTask
                {
                    Id = 29,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 7
                },
                new MyPregnancyTrackerTask
                {
                    Id = 30,
                    Content = "Заредете чантата си с ментови или евкалиптови бонбони за \"спешна помощ\", ако Ви предстоят ангажименти извън дома.",
                    GestationalWeekId = 8
                },
                new MyPregnancyTrackerTask
                {
                    Id = 31,
                    Content = "Включето провеждането на биохимичен скрининг в списъка с въпроси за Вашия лекар.",
                    GestationalWeekId = 8
                },
                new MyPregnancyTrackerTask
                {
                    Id = 32,
                    Content = "Ако не се чувствате добре, отменете всички задачи и ангажименти, които не са от непосредствена важност, без значение дали са служебни семейни или социални.",
                    GestationalWeekId = 8
                },
                new MyPregnancyTrackerTask
                {
                    Id = 33,
                    Content = "Ако още не сте записали час за фетална морфология, направете го сега.",
                    GestationalWeekId = 8
                },
                new MyPregnancyTrackerTask
                {
                    Id = 34,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 9
                },
                new MyPregnancyTrackerTask
                {
                    Id = 35,
                    Content = "Разгледайте гардероба си и приберете всички дрехи, които вече са Ви твърде тесни или са направени от неподходящи материи.",
                    GestationalWeekId = 9
                },
                new MyPregnancyTrackerTask
                {
                    Id = 36,
                    Content = "Посетете козметичен магазин или аптека и изберете козметика против стрии.",
                    GestationalWeekId = 9
                },
                new MyPregnancyTrackerTask
                {
                    Id = 37,
                    Content = "Обсъдете с партньора си нуждата и възможността да направите ранен тест за пренатална диагностика.",
                    GestationalWeekId = 9
                },
                new MyPregnancyTrackerTask
                {
                    Id = 38,
                    Content = "Планирайте кратка семейна почивка или излет сред природата, ако се чувствате достатъчно добре.",
                    GestationalWeekId = 10
                },
                new MyPregnancyTrackerTask
                {
                    Id = 39,
                    Content = "Започнете да спите на лявата си страна, за да изградите полезни навици за по-късния период на бременността.",
                    GestationalWeekId = 10
                },
                new MyPregnancyTrackerTask
                {
                    Id = 40,
                    Content = "Заедно с бъдещия татко планирайте как ще съобщите за бременността си сред близките и приятелите си.",
                    GestationalWeekId = 10
                },
                new MyPregnancyTrackerTask
                {
                    Id = 41,
                    Content = "Прегледайте домакинските препарати и отделете настрана тези, които съдъжат белина, както и силните обезмаслители.Помолете партньора си да поеме чистенето с тях.",
                    GestationalWeekId = 10
                },
                new MyPregnancyTrackerTask
                {
                    Id = 42,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 11
                },
                new MyPregnancyTrackerTask
                {
                    Id = 43,
                    Content = "Започнете да следите вагиналното си течение.",
                    GestationalWeekId = 11
                },
                new MyPregnancyTrackerTask
                {
                    Id = 44,
                    Content = "Приберете обувките на високи токове и се снабдете с ниски и удобни модели.",
                    GestationalWeekId = 11
                },
                new MyPregnancyTrackerTask
                {
                    Id = 45,
                    Content = "Потърсете информация за безопасни хомеопатични и ароматерапевтични средства, способстващи за добър сън и релакс.",
                    GestationalWeekId = 11
                },
                new MyPregnancyTrackerTask
                {
                    Id = 46,
                    Content = "Планирайте менюто си за няколко дни напред.",
                    GestationalWeekId = 12
                },
                new MyPregnancyTrackerTask
                {
                    Id = 47,
                    Content = "Прегледайте и прочистете кухненските шкафове и хладилника.",
                    GestationalWeekId = 12
                },
                new MyPregnancyTrackerTask
                {
                    Id = 48,
                    Content = "Свържете се със зъболекар и уговорете час за профилактичен преглед.",
                    GestationalWeekId = 12
                },
                new MyPregnancyTrackerTask
                {
                    Id = 49,
                    Content = "Ако сте вегетарианка или напоследък нямате никакъв апетит за месо и яйца, помолете лекаря си да Ви препоръча подходяща хранителна добавка.",
                    GestationalWeekId = 12
                },
                new MyPregnancyTrackerTask
                {
                    Id = 50,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 13
                },
                new MyPregnancyTrackerTask
                {
                    Id = 51,
                    Content = "Направете си \"бременна\" снимка.",
                    GestationalWeekId = 13
                },
                new MyPregnancyTrackerTask
                {
                    Id = 52,
                    Content = "Изберете си подходящо слънцезащитно средство.",
                    GestationalWeekId = 13
                },
                new MyPregnancyTrackerTask
                {
                    Id = 53,
                    Content = "Прегледайте хладилника и шкафа с продукти за готвене и изхвърлете всички продукти, съдържащи хидрогенирани растителни мазнини - купете на тяхно място зехтин, масло и други качествени заместители.",
                    GestationalWeekId = 13
                },
                new MyPregnancyTrackerTask
                {
                    Id = 54,
                    Content = "Изненадайте партньора с предложение за ненатоварващо и забвано съвместно преживяване.",
                    GestationalWeekId = 14
                },
                new MyPregnancyTrackerTask
                {
                    Id = 55,
                    Content = "Разпределете седмичните си задачи така, че да се възползвате от повишената енергия, без да се претоварвате.",
                    GestationalWeekId = 14
                },
                new MyPregnancyTrackerTask
                {
                    Id = 56,
                    Content = "Започнете да планирате промените в семейното жилище.",
                    GestationalWeekId = 14
                },
                new MyPregnancyTrackerTask
                {
                    Id = 57,
                    Content = "Изберете подходящ спорт за бременни.",
                    GestationalWeekId = 14
                },
                new MyPregnancyTrackerTask
                {
                    Id = 58,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 15
                },
                new MyPregnancyTrackerTask
                {
                    Id = 59,
                    Content = "Започнете да практикувате упражнения на Кегел.",
                    GestationalWeekId = 15
                },
                new MyPregnancyTrackerTask
                {
                    Id = 60,
                    Content = "Разговаряйте с по-голямото си дете за идващото бебе.",
                    GestationalWeekId = 15
                },
                new MyPregnancyTrackerTask
                {
                    Id = 61,
                    Content = "Планирайте седмичното си меню, като включите в него подходящи източници на калций.",
                    GestationalWeekId = 15
                },
                new MyPregnancyTrackerTask
                {
                    Id = 62,
                    Content = "Обсъдете с партньора си възможността да инвестирате в покупки, които ще улеснят домакинството ви в бъдеще.",
                    GestationalWeekId = 16
                },
                new MyPregnancyTrackerTask
                {
                    Id = 63,
                    Content = "Огледайте колекциите от дрехи за бременни в специализираните магазини в интернет.",
                    GestationalWeekId = 16
                },
                new MyPregnancyTrackerTask
                {
                    Id = 64,
                    Content = "Потърсете организирани групи за бременни във Вашия град или район или се включете в такива групи във форумите и социалните мрежи.",
                    GestationalWeekId = 16
                },
                new MyPregnancyTrackerTask
                {
                    Id = 65,
                    Content = "Ако вече усещате подготвителни контракции, започнете да записвате честотата им.",
                    GestationalWeekId = 16
                },
                new MyPregnancyTrackerTask
                {
                    Id = 66,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 17
                },
                new MyPregnancyTrackerTask
                {
                    Id = 67,
                    Content = "Запишете час за втора фетална морфология.",
                    GestationalWeekId = 17
                },
                new MyPregnancyTrackerTask
                {
                    Id = 68,
                    Content = "Започнете да прочиствате и подреждате дома си.Бъдете методични и не бързайте: действайте стая по стая и шкаф по шкаф.",
                    GestationalWeekId = 17
                },
                new MyPregnancyTrackerTask
                {
                    Id = 69,
                    Content = "Уговорете си среща със старите \"свободни\" приятели.",
                    GestationalWeekId = 17
                },
                new MyPregnancyTrackerTask
                {
                    Id = 70,
                    Content = "Намерете време за разходка на чист въздух и превърнете това в навик.",
                    GestationalWeekId = 18
                },
                new MyPregnancyTrackerTask
                {
                    Id = 71,
                    Content = "Опитайте упражнението \"котешки гръб\", за да подобрите гъвкавостта на гръбнака.Ако Ви допадне, тествайте и други подходящи йога пози.",
                    GestationalWeekId = 18
                },
                new MyPregnancyTrackerTask
                {
                    Id = 72,
                    Content = "Включете общуването с бебето в списъка си с ежедневни задачи.",
                    GestationalWeekId = 18
                },
                new MyPregnancyTrackerTask
                {
                    Id = 73,
                    Content = "Ако изпитвате съмнения или дискомфорт по отношение на лекаря си, поручете с кого и кога ще е най-удобно да го смените.",
                    GestationalWeekId = 18
                },
                new MyPregnancyTrackerTask
                {
                    Id = 74,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 19
                },
                new MyPregnancyTrackerTask
                {
                    Id = 75,
                    Content = "Направете списък с бебешки имена, които да обсъдите с партньора си.",
                    GestationalWeekId = 19
                },
                new MyPregnancyTrackerTask
                {
                    Id = 76,
                    Content = "Уверете се, че в седмичното Ви меню присъстват достатъчно храни, богати на желязо.",
                    GestationalWeekId = 19
                },
                new MyPregnancyTrackerTask
                {
                    Id = 77,
                    Content = "Ако се чувствате твърде уморена и нямате енергия, свържете се с лекаря си и обсъдете какви изследвания ще са Ви необходими.",
                    GestationalWeekId = 19
                },
                new MyPregnancyTrackerTask
                {
                    Id = 78,
                    Content = "Запишете приоритетите си във връзка с избора на родилен дом.",
                    GestationalWeekId = 20
                },
                new MyPregnancyTrackerTask
                {
                    Id = 79,
                    Content = "При планирането на седмичното си меню се уверете, че приемате достатъчно храни, съдържащи витамин B12.",
                    GestationalWeekId = 20
                },
                new MyPregnancyTrackerTask
                {
                    Id = 80,
                    Content = "Ако не консумирате животински продукти, обсъдете с лекаря си дали са Ви нужни иследвания и хранителни добавки със съдържание на кобаламин.",
                    GestationalWeekId = 20
                },
                new MyPregnancyTrackerTask
                {
                    Id = 81,
                    Content = "Обсъдете с партньора си възможността и нуждата от сухранение на стволови клетки на вашето бебе.",
                    GestationalWeekId = 20
                },
                new MyPregnancyTrackerTask
                {
                    Id = 82,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 21
                },
                new MyPregnancyTrackerTask
                {
                    Id = 83,
                    Content = "Сложете няколко кристалчета морска сол в чантата или портфейла си.",
                    GestationalWeekId = 21
                },
                new MyPregnancyTrackerTask
                {
                    Id = 84,
                    Content = "Направете списък на здравните заведения с родилно отделение близо до района, в който живеете.",
                    GestationalWeekId = 21
                },
                new MyPregnancyTrackerTask
                {
                    Id = 85,
                    Content = "Прегледайте шкафчето си с бельо и отстранете от него всички бикини и стрингове от изкуствени материи.",
                    GestationalWeekId = 21
                },
                new MyPregnancyTrackerTask
                {
                    Id = 86,
                    Content = "Заменете трапезната сол в шкафчето с попдравки с морска, хималайска или друга естествена сол.",
                    GestationalWeekId = 22
                },
                new MyPregnancyTrackerTask
                {
                    Id = 87,
                    Content = "Запознайте се с предстоящите разпродажби и промоции в бебешките магазини.",
                    GestationalWeekId = 22
                },
                new MyPregnancyTrackerTask
                {
                    Id = 88,
                    Content = "Ако страдате от симптоми на предродилна депресия, премахнете повечето форуми и женски сайтове от обичайно посещаваните места в интернет.",
                    GestationalWeekId = 22
                },
                new MyPregnancyTrackerTask
                {
                    Id = 89,
                    Content = "Обсъдете с лекаря си дали не е нужно да си направите специални изследвания на нивата на желязо и витамин В12.",
                    GestationalWeekId = 22
                },
                new MyPregnancyTrackerTask
                {
                    Id = 90,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 23
                },
                new MyPregnancyTrackerTask
                {
                    Id = 91,
                    Content = "Ако страдате от симптоми на предродилна депресия, потърсете хомеопат, който да Ви препоръча подходящо лечение.",
                    GestationalWeekId = 23
                },
                new MyPregnancyTrackerTask
                {
                    Id = 92,
                    Content = "При избора на родилен дом обмислете дали искате бебето да бъде във Вашата стая веднага след раждането, или предпочитате да сте с него само в определени часове.",
                    GestationalWeekId = 23
                },
                new MyPregnancyTrackerTask
                {
                    Id = 93,
                    Content = "Не допускайте да се заседявате дълго време - ставайте и раздвижвайте гръбнака си напред назад.",
                    GestationalWeekId = 23
                },
                new MyPregnancyTrackerTask
                {
                    Id = 94,
                    Content = "Обсъдете с партньора си дали би искал да присъства на раждането и доколко това е съществен критерий за вас при избора за заведение за раждане.",
                    GestationalWeekId = 24
                },
                new MyPregnancyTrackerTask
                {
                    Id = 95,
                    Content = "Запишете се на курсове или семинари за бъдещи родители.",
                    GestationalWeekId = 24
                },
                new MyPregnancyTrackerTask
                {
                    Id = 96,
                    Content = "Отделете време за слънчеви бани в дневния си режим, особено ако страдате от тъга и безпокойство.",
                    GestationalWeekId = 24
                },
                new MyPregnancyTrackerTask
                {
                    Id = 97,
                    Content = "Изберете подходящи козметични средства в зависимост от промените в кожата си.",
                    GestationalWeekId = 24
                },
                new MyPregnancyTrackerTask
                {
                    Id = 98,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 25
                },
                new MyPregnancyTrackerTask
                {
                    Id = 99,
                    Content = "Обсъдете с лекаря си нуждата от носене на колан за бременни и нуждата от изследвания на нивата на витамин D.",
                    GestationalWeekId = 25
                },
                new MyPregnancyTrackerTask
                {
                    Id = 100,
                    Content = "Включете асаната \"Дърво\" в минутите си за физическа активност.",
                    GestationalWeekId = 25
                },
                new MyPregnancyTrackerTask
                {
                    Id = 101,
                    Content = "Разхождайте се на слънце при всяка възможност, като избягвате горещите часове на деня.",
                    GestationalWeekId = 25
                },
                new MyPregnancyTrackerTask
                {
                    Id = 102,
                    Content = "Обиколете магазините за нов размер дрехи за бременни или си поръчайте онлайн.",
                    GestationalWeekId = 26
                },
                new MyPregnancyTrackerTask
                {
                    Id = 103,
                    Content = "Запишете си час за профилактичен преглед при зъболекар.",
                    GestationalWeekId = 26
                },
                new MyPregnancyTrackerTask
                {
                    Id = 104,
                    Content = "Създайте навик да \"глезите\" краката си с хладка вана, в която сте разтворили соли или ароматни масла.",
                    GestationalWeekId = 26
                },
                new MyPregnancyTrackerTask
                {
                    Id = 105,
                    Content = "Заредете хладилника с няколко кофички заквасена сметана за бърза и здравословна междинна закуска.",
                    GestationalWeekId = 26
                },
                new MyPregnancyTrackerTask
                {
                    Id = 106,
                    Content = "Съветваме Ви да замените крема с олио против стрии.",
                    GestationalWeekId = 26
                },
                new MyPregnancyTrackerTask
                {
                    Id = 107,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 27
                },
                new MyPregnancyTrackerTask
                {
                    Id = 108,
                    Content = "Направете списък на ценните храни, които отбягвате поради липса на апетит.Потърсете рецепти и идеи за вклюването им в менюто Ви по \"нестандартен\" начин.",
                    GestationalWeekId = 27
                },
                new MyPregnancyTrackerTask
                {
                    Id = 109,
                    Content = "Изпробвайте различни пози за спане и си помагайте с възглавници, за да намерите най-удбоната позиция за сън и почивка.",
                    GestationalWeekId = 27
                },
                new MyPregnancyTrackerTask
                {
                    Id = 110,
                    Content = "Започнете да водите дневник на движенията на бебето.",
                    GestationalWeekId = 27
                },
                new MyPregnancyTrackerTask
                {
                    Id = 111,
                    Content = "Подгответе подробен списък на мебелите и вещите, с които трябва да се снабдите в очакване на бебето.",
                    GestationalWeekId = 28
                },
                new MyPregnancyTrackerTask
                {
                    Id = 112,
                    Content = "Проучете кога има \"дни на отворените врати\" в здравните заведения, които отговарят на изискванията Ви за предстоящото раждане.",
                    GestationalWeekId = 28
                },
                new MyPregnancyTrackerTask
                {
                    Id = 113,
                    Content = "Намерете надеждни и обективни източници на информация за раждането, за да започнете да се подготвяте психологически за него.",
                    GestationalWeekId = 28
                },
                new MyPregnancyTrackerTask
                {
                    Id = 114,
                    Content = "Ако не искате да купувате много неща преди раждането, започнете да отбелязвате в списъка избраните марки и модели, за да улесните пазаруването в бъдеще.",
                    GestationalWeekId = 28
                },
                new MyPregnancyTrackerTask
                {
                    Id = 115,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 29
                },
                new MyPregnancyTrackerTask
                {
                    Id = 116,
                    Content = "Намерете място за киноата в седмичното си меню - в интернет можете да намерите голямо разнообразие от рецепти.",
                    GestationalWeekId = 29
                },
                new MyPregnancyTrackerTask
                {
                    Id = 117,
                    Content = "Обиколете магазините за бебешки вещи и изпробвайте различни модели колички.",
                    GestationalWeekId = 29
                },
                new MyPregnancyTrackerTask
                {
                    Id = 118,
                    Content = "Създайте си навика да вдигате краката нависоко при почивка, четене на книга и гледане на филм.",
                    GestationalWeekId = 29
                },
                new MyPregnancyTrackerTask
                {
                    Id = 119,
                    Content = "Започнете активно да търсите информация за избрания от Вас начин на хранене на бебето.",
                    GestationalWeekId = 30
                },
                new MyPregnancyTrackerTask
                {
                    Id = 120,
                    Content = "Изберете детски лекар за Вашето бебе.",
                    GestationalWeekId = 30
                },
                new MyPregnancyTrackerTask
                {
                    Id = 121,
                    Content = "Обмислете възможностите си за избор на екип за раждане.",
                    GestationalWeekId = 30
                },
                new MyPregnancyTrackerTask
                {
                    Id = 122,
                    Content = "Ако сте избрали лекаря, който искате да води раждането Ви, опитайте се да уговорите среща с него в близко време.",
                    GestationalWeekId = 30
                },
                new MyPregnancyTrackerTask
                {
                    Id = 123,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 31
                },
                new MyPregnancyTrackerTask
                {
                    Id = 124,
                    Content = "Купете си корен джинджифил или пакетчета джинджифилов чай за облекчаване на киселините.",
                    GestationalWeekId = 31
                },
                new MyPregnancyTrackerTask
                {
                    Id = 125,
                    Content = "Обмислете дали искате да ползвате епидурална упойка при раждането.",
                    GestationalWeekId = 31
                },
                new MyPregnancyTrackerTask
                {
                    Id = 126,
                    Content = "Бъдете упорита в изпълнението на кегеловите упражнения.",
                    GestationalWeekId = 31
                },
                new MyPregnancyTrackerTask
                {
                    Id = 127,
                    Content = "Свържете се с консултатн по кърмене, за да зададете въпросите, които ви вълнуват още отсега.",
                    GestationalWeekId = 32
                },
                new MyPregnancyTrackerTask
                {
                    Id = 128,
                    Content = "Потърсете в интернет рецепти за приготвяне на чия.",
                    GestationalWeekId = 32
                },
                new MyPregnancyTrackerTask
                {
                    Id = 129,
                    Content = "Потърсете информация за различни техники за безболезнено раждане и започнете да ги упражнявате.",
                    GestationalWeekId = 32
                },
                new MyPregnancyTrackerTask
                {
                    Id = 130,
                    Content = "Абе бебето ви е в седалищна позиция , опитайте да го накарате да се обърне чрез упражнения (първо се посъветвайте с лкаря си).",
                    GestationalWeekId = 32
                },
                new MyPregnancyTrackerTask
                {
                    Id = 131,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 33
                },
                new MyPregnancyTrackerTask
                {
                    Id = 132,
                    Content = "Обогатете менюто си с храни, които могат да противодействат на запека и хемороидите.",
                    GestationalWeekId = 33
                },
                new MyPregnancyTrackerTask
                {
                    Id = 133,
                    Content = "Сравнявайте движенията на бебето с данните, които сте въвела в нашия модул за регистриране на неговата активност или сте записала в дневника си.",
                    GestationalWeekId = 33
                },
                new MyPregnancyTrackerTask
                {
                    Id = 134,
                    Content = "Подготвайте дома си за бебето, без да се натоварвате с излишна работа.",
                    GestationalWeekId = 33
                },
                new MyPregnancyTrackerTask
                {
                    Id = 135,
                    Content = "Приберете документите за постъпване в болница на едно място, за да не се налага да ги търсите в последния момент.",
                    GestationalWeekId = 34
                },
                new MyPregnancyTrackerTask
                {
                    Id = 136,
                    Content = "Започентете да приготвяте бажажа си за родилното отделение.",
                    GestationalWeekId = 34
                },
                new MyPregnancyTrackerTask
                {
                    Id = 137,
                    Content = "Помолете партньора си да заведе домашния любимец на контролен преглед при ветеринар.",
                    GestationalWeekId = 34
                },
                new MyPregnancyTrackerTask
                {
                    Id = 138,
                    Content = "Актуализирайте списъка с покупки за бебето, като включите само неща от които наистина имате нужда.",
                    GestationalWeekId = 34
                },
                new MyPregnancyTrackerTask
                {
                    Id = 139,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 35
                },
                new MyPregnancyTrackerTask
                {
                    Id = 140,
                    Content = "Включете червена леща в седмичното си меню.",
                    GestationalWeekId = 35
                },
                new MyPregnancyTrackerTask
                {
                    Id = 141,
                    Content = "Насрочете си среща с лекаря, когото сте избрала за раждането, или посетете избраното здравно заведение в приемното му време.",
                    GestationalWeekId = 35
                },
                new MyPregnancyTrackerTask
                {
                    Id = 142,
                    Content = "Поставете задачи на по-голямото си дете във връзка с подготовката за бебето.",
                    GestationalWeekId = 35
                },
                new MyPregnancyTrackerTask
                {
                    Id = 143,
                    Content = "Уверете се, че пиете достатъчно течности.",
                    GestationalWeekId = 36
                },
                new MyPregnancyTrackerTask
                {
                    Id = 144,
                    Content = "Включете папаята в седмичното си меню.",
                    GestationalWeekId = 36
                },
                new MyPregnancyTrackerTask
                {
                    Id = 145,
                    Content = "Помолете ваши роднини или приятели да ви подарят част от нещата в списъка с покупки за бебето.",
                    GestationalWeekId = 36
                },
                new MyPregnancyTrackerTask
                {
                    Id = 146,
                    Content = "Купете комплет за изписване на бебето, помолете някой близък да ви подари такъв или направете свой комплект от дрежки и завивки, които ви допадат.",
                    GestationalWeekId = 36
                },
                new MyPregnancyTrackerTask
                {
                    Id = 147,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 37
                },
                new MyPregnancyTrackerTask
                {
                    Id = 148,
                    Content = "Потърсете подходящи хомеопатични или ароматеравпевтични средства за по-добър сън.",
                    GestationalWeekId = 37
                },
                new MyPregnancyTrackerTask
                {
                    Id = 149,
                    Content = "Обяснете на по-голямото си дете, че ще бъдете в болница за раждането на бебето и в първите дни след това.",
                    GestationalWeekId = 37
                },
                new MyPregnancyTrackerTask
                {
                    Id = 150,
                    Content = "Обсъдете с партньора си дали ще ползвате помоща на бабите след раждането на бебето и дали има нужда и възможност да ги приемете в дома си.",
                    GestationalWeekId = 37
                },
                new MyPregnancyTrackerTask
                {
                    Id = 151,
                    Content = "Запишете си зас за коламаска на интимната зона.",
                    GestationalWeekId = 38
                },
                new MyPregnancyTrackerTask
                {
                    Id = 152,
                    Content = "Уговорете си среща с близка приятелка, купете билет за кино или планирайте друго занимание, което да ви разсее от мислите за предстоящото раждане.",
                    GestationalWeekId = 38
                },
                new MyPregnancyTrackerTask
                {
                    Id = 153,
                    Content = "Преговорете си основните фази и етапи, през които преминава естественото раждане.",
                    GestationalWeekId = 38
                },
                new MyPregnancyTrackerTask
                {
                    Id = 154,
                    Content = "Работете върху изграждането на положителна, спокойна и реалистична нагласа за раждането.",
                    GestationalWeekId = 38
                },
                new MyPregnancyTrackerTask
                {
                    Id = 155,
                    Content = "Измерете теглото си и запишете резултата.",
                    GestationalWeekId = 39
                },
                new MyPregnancyTrackerTask
                {
                    Id = 156,
                    Content = "Пригответе си дрехи и козметика за изписването и ги приберете при комплекта за изписване на бебето.",
                    GestationalWeekId = 39
                },
                new MyPregnancyTrackerTask
                {
                    Id = 157,
                    Content = "Планирайте дали и как ще оппразнувате появата на бебето и след излизането от болницата.",
                    GestationalWeekId = 39
                },
                new MyPregnancyTrackerTask
                {
                    Id = 158,
                    Content = "Включете в менто си \"сухи\" нишестени храни, ако чувствате стомаха си леко разтроен.",
                    GestationalWeekId = 39
                },
                new MyPregnancyTrackerTask
                {
                    Id = 159,
                    Content = "Купете си качествен шоколоад с високо съдържание на какао и го запазете за .началото на родилния процес.",
                    GestationalWeekId = 40
                },
                new MyPregnancyTrackerTask
                {
                    Id = 160,
                    Content = "Добавете в багажса си за родилното отделение малка бутилка минерална вода.",
                    GestationalWeekId = 40
                },
                new MyPregnancyTrackerTask
                {
                    Id = 161,
                    Content = "Вземете топъл душ или вана, за да отпуснете мускулите преди раждането.",
                    GestationalWeekId = 40
                },
                new MyPregnancyTrackerTask
                {
                    Id = 162,
                    Content = "Ако сте много напрегната, опитайте се да се разсеете със съвсем странични дейности и занимания.",
                    GestationalWeekId = 40
                },
                new MyPregnancyTrackerTask
                {
                    Id = 163,
                    Content = "Включете в менюто си покантни и люти храни.",
                    GestationalWeekId = 41
                },
                new MyPregnancyTrackerTask
                {
                    Id = 164,
                    Content = "Направете си дълга разходка, след което вземете топла вана или душ.",
                    GestationalWeekId = 41
                },
                new MyPregnancyTrackerTask
                {
                    Id = 165,
                    Content = "Обмислете използването на хомеопатично средств, акупунктура или акупресура в опит да ускорите родилния процес.",
                    GestationalWeekId = 41
                },
                new MyPregnancyTrackerTask
                {
                    Id = 166,
                    Content = "Опитайте да предизвикате раждането чрез сексуална стимулация.",
                    GestationalWeekId = 41
                },
                new MyPregnancyTrackerTask
                {
                    Id = 167,
                    Content = "Попитайте лекаря си дали можете да използвате билкови чайове или рициново масл като средство за спонтанно предизвикване на раждане.",
                    GestationalWeekId = 42
                },
                new MyPregnancyTrackerTask
                {
                    Id = 168,
                    Content = "Намерете странично занимание, което изисква висока степен на концентрация , за да се разсеете от напрегнатото очакване.",
                    GestationalWeekId = 42
                },
                new MyPregnancyTrackerTask
                {
                    Id = 169,
                    Content = "Запазете си час за масаж в близките дни.",
                    GestationalWeekId = 42
                },
                new MyPregnancyTrackerTask
                {
                    Id = 170,
                    Content = "Разгледайте нашето приложение за родители, за да се подготвите за предствоящите грижи за новороденото.",
                    GestationalWeekId = 42
                }
               );
        }
    }
}
