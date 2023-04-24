﻿using SubstringSearchAlgorithms;
using SubstringSearchAlgorithms.Class;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchers = new ISustringSearcher[]
            {
                new RabinKarp(),
                new Brutforce(),
                new BoyerMoor(),
                new KnutMorisPrat()
            };
            foreach(var searcher in searchers)
            {
                SubstringSearcherPerformanceTest(searcher);
            }
        }
        static void SubstringSearcherPerformanceTest(ISustringSearcher searcher)
        {
            var str = File.ReadAllText("WarAndWorld.txt");
            var subStr = mediumSubstring;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var idxs = searcher.IndexOf(str, 0, subStr);

            stopWatch.Stop();

            Console.WriteLine($"{searcher.GetType().Name}: time: {stopWatch.ElapsedMilliseconds}, founded: {idxs.Length}");
        }

        static string veryShortSubstring = "и";

        static string shortSubstring = "Андрей";

        static string mediumSubstring = @"Приехав в Петербург, Пьер никого не известил о своем приезде, никуда не выезжал и стал целые дни проводить за чтением Фомы Кемпийского, книги, которая неизвестно кем была доставлена ему. Одно и все одно понимал Пьер, читая эту книгу: он понимал неизведанное еще им наслаждение верить в возможность достижения совершенства и в возможность братской и деятельной любви между людьми, открытую ему Осипом Алексеевичем. Через неделю после его приезда молодой польский граф Вилларский, которого Пьер поверхностно знал по петербургскому свету, вошел вечером в его комнату с тем официальным и торжественным видом, с которым входил к нему секундант Долохова, и, затворив за собой дверь и убедившись, что в комнате никого, кроме Пьера, не было, обратился к нему.

– Я приехал к вам с предложением и поручением, граф, – сказал он ему, не садясь. – Особа, очень высоко поставленная в нашем братстве, ходатайствовала о том, чтобы вы были приняты в братство ранее срока, и предложила мне быть вашим поручителем. Я за священный долг почитаю исполнение воли этого лица. Желаете ли вы вступить за моим поручительством в братство свободных каменщиков?

Холодный и строгий тон человека, которого Пьер видел почти всегда на балах с любезной улыбкою, в обществе самых блестящих женщин, поразил Пьера.

– Да, я желаю, – сказал Пьер.

Вилларский наклонил голову.

– Еще один вопрос, граф, – сказал он, – на который я вас не как будущего масона, но как честного человека (galant homme) прошу со всею искренностью отвечать мне: отреклись ли вы от своих прежних убеждений, верите ли вы в Бога?

Пьер задумался.

– Да… да, я верю в Бога, – сказал он.

– В таком случае… – начал Вилларский, но Пьер перебил его.

– Да, я верю в Бога, – сказал он еще раз.

– В таком случае мы можем ехать, – сказал Вилларский. – Карета моя к вашим услугам.

Всю дорогу Вилларский молчал. На вопросы Пьера, что ему нужно делать и как отвечать, Вилларский сказал только, что братья, более его достойные, испытают его и что Пьеру больше ничего не нужно, как говорить правду.

Въехав в ворота большого дома, где было помещение ложи, и пройдя по темной лестнице, они вошли в освещенную небольшую прихожую, где без помощи прислуги сняли шубы. Из передней они прошли в другую комнату. Какой-то человек в странном одеянии показался у двери. Вилларский, выйдя к нему навстречу, что-то тихо сказал ему по-французски и подошел к небольшому шкафу, в котором Пьер заметил различные не виданные им одеяния. Взяв из шкафа платок, Вилларский наложил его на глаза Пьеру и завязал узлом сзади, больно захватив в узел его волоса. Потом он пригнул его к себе, поцеловал и, взяв за руку, повел куда-то. Пьеру было больно от притянутых узлом волос, он морщился от боли и улыбался от стыда чего-то. Огромная фигура его с опущенными руками, с сморщенной и улыбающейся физиономией неверными, робкими шагами подвигалась за Вилларским.

Проведя его шагов десять за руку, Вилларский остановился.

– Что бы ни случилось с вами, – сказал он, – вы должны с мужеством переносить все, ежели вы твердо решились вступить в наше братство. (Пьер утвердительно отвечал наклонением головы.) Когда вы услышите стук в двери, вы развяжете себе глаза, – прибавил Вилларский, – желаю вам мужества и успеха. – И, пожав руку Пьеру, Вилларский вышел.

Оставшись один, Пьер продолжал все так же улыбаться. Раза два он пожимал плечами, подносил руку к платку, как бы желая снять его, и опять опускал ее. Пять минут, которые он пробыл с завязанными глазами, показались ему часом. Руки его отекли, ноги подкашивались; ему казалось, что он устал. Он испытывал самые сложные и разнообразные чувства. Ему было и страшно того, что с ним случится, и еще более страшно того, как бы ему не выказать страха. Ему было любопытно узнать, что будет с ним, что откроется ему; но более всего ему было радостно, что наступила минута, когда он, наконец, вступит на тот путь обновления и деятельно-добродетельной жизни, о котором он мечтал со времени своей встречи с Осипом Алексеевичем. В дверь послышались сильные удары. Пьер снял повязку и оглянулся вокруг себя. В комнате было черно-темно: только в одном месте горела лампада в чем-то белом. Пьер подошел ближе и увидал, что лампада стояла на черном столе, на котором лежала одна раскрытая книга. Книга была Евангелие; то белое, в чем горела лампада, был человечий череп с своими дырами и зубами. Прочтя первые слова Евангелия: «В начале бе слово и слово бе к Богу», Пьер обошел стол и увидал большой, наполненный чем-то и открытый ящик. Это был гроб с костями. Его нисколько не удивило то, что он увидал. Надеясь вступить в совершенно новую жизнь, совершенно отличную от прежней, он ожидал всего необыкновенного, еще более необыкновенного, чем то, что он видел. Череп, гроб, Евангелие – ему казалось, что он ожидал всего этого, ожидал еще большего. Стараясь вызвать в себе чувство умиленья, он смотрел вокруг себя. «Бог, смерть, любовь, братство людей», – говорил он себе, связывая с этими словами смутные, но радостные представления чего-то. Дверь отворилась, и кто-то вошел.

При слабом свете, к которому, однако, уже успел Пьер приглядеться, вошел невысокий человек. Видимо, с света войдя в темноту, человек этот остановился; потом осторожными шагами он подвинулся к столу и положил на него небольшие, закрытые кожаными перчатками руки.

Невысокий человек этот был одет в белый кожаный фартук, прикрывавший его грудь и часть ног, на шее было надето что-то вроде ожерелья, и из-за ожерелья выступал высокий белый жабо, окаймлявший его продолговатое лицо, освещенное снизу.

– Для чего вы пришли сюда? – спросил вошедший, по шороху, сделанному Пьером, обращаясь в его сторону. – Для чего вы, не верующий в истины света и не видящий света, для чего вы пришли сюда, чего хотите вы от нас? Премудрости, добродетели, просвещения?

В ту минуту, как дверь отворилась и вошел неизвестный человек, Пьер испытал чувство страха и благоговения, подобное тому, которое он в детстве испытывал на исповеди: он почувствовал себя с глазу на глаз с совершенно чужим по условиям жизни и с близким по братству людей человеком. Пьер с захватывающим дыханье биением сердца подвинулся к ритору (так назывался в масонстве брат, приготовляющий ищущего к вступлению в братство). Пьер, подойдя ближе, узнал в риторе знакомого человека, Смольянинова, но ему оскорбительно было думать, что вошедший был знакомый человек: вошедший был только брат и добродетельный наставник. Пьер долго не мог выговорить слова, так что ритор должен был повторить свой вопрос.

– Да, я… я… хочу обновления, – с трудом выговорил Пьер.

– Хорошо, – сказал Смольянинов и тотчас же продолжал: – Имеете ли вы понятие о средствах, которыми наш святой орден поможет вам в достижении вашей цели?.. – сказал ритор спокойно и быстро.

– Я… надеюсь… руководства… помощи… в обновлении, – сказал Пьер с дрожанием голоса и с затруднением в речи, происходящим и от волнения и от непривычки говорить по-русски об отвлеченных предметах.

– Какое понятие вы имеете о франкмасонстве?";
    }
}
