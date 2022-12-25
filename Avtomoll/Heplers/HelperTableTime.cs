using Avtomoll.ViewModel.ReceptionModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Text.Encodings.Web;

namespace Avtomoll.Heplers
{
    public static class HelperTableTime
    {
        public static HtmlString TableBootstrap(
    this IHtmlHelper helper,
    ReceptionViewModel model)
        {
            var tagDiv = new TagBuilder("div");

            int countColumn = model.TimeReception.GetLength(1);

            int limitColumn;

            if (countColumn % 2 == 1)
            {
                limitColumn = (countColumn / 2) + 1;
                countColumn += 1;
            }
            else
            {
                limitColumn = (countColumn / 2) + 1;
                countColumn += 2;
            }

            var timeOpenService = model.TimeOpenCarservice;

            int progressColumn = 0;

            var timeReception = model.TimeReception;

            for (int i = 0; i < 2; i++)
            {
                CreateTable(countColumn, ref timeOpenService, tagDiv, timeReception, limitColumn, progressColumn, model.TimeReception.Length, i);
                progressColumn += limitColumn;
            }

            var writer = new System.IO.StringWriter();
            tagDiv.AddCssClass("mt-4");
            tagDiv.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }

        private static void CreateTable(int countColumn, ref DateTime time, TagBuilder div, DataReception[,] timeReseption, int limitColumn, int progressColumn, int timeJob, int currentTable)
        {
            var tagTable = new TagBuilder("table");
            tagTable.AddCssClass("mt-4");
            tagTable.AddCssClass("table-bordered");
            //tagTable.AddCssClass("table");
            var tagTr = new TagBuilder("tr");
            int count = 0;

            // Заголовок таблицы (временная шкала)
            for (int i = progressColumn; i < countColumn; i++)
            {
                var tagTh = new TagBuilder("th");
                tagTh.InnerHtml.SetContent(time.ToString("HH:mm"));
                if (i >= timeJob)
                {
                    tagTh.AddCssClass("bg-light");
                }

                tagTr.InnerHtml.AppendHtml(tagTh);
                time = time.AddMinutes(30);
                count +=1;
                if(count == limitColumn)
                {
                    break;
                }
            }

            var tagThead = new TagBuilder("thead");
            tagThead.InnerHtml.AppendHtml(tagTr);
            tagTable.InnerHtml.AppendHtml(tagThead);

            var tagTbody = new TagBuilder("tbody");
            
            for (int j = 0; j < timeReseption.GetLength(0); j++)
            {
                tagTr = new TagBuilder("tr");
                count = 0;

                for (int i = progressColumn; i < countColumn; i++)
                {
                    var tagTd = new TagBuilder("td");

                    if (i < timeReseption.GetLength(1))
                    {
                        if (timeReseption[j, i] != null)
                        {
                            var tagA = new TagBuilder("a");
                            tagA.MergeAttribute("href", $"/manager/service/Details?LeadId=" + timeReseption[j, i].ServiceHistoryId);
                            var tagDiv = new TagBuilder("div");
                            tagA.Attributes["style"] = "width: 100%; height: 100%;";
                            tagA.AddCssClass("bg-success");
                            tagDiv.InnerHtml.SetContent(timeReseption[j, i].Time.Hour.ToString() + ":" + timeReseption[j, i].Time.Minute.ToString());
                            tagA.InnerHtml.AppendHtml(tagDiv);
                            tagTd.Attributes["style"] = "background-color: #a4dcff;";
                            tagTd.Attributes["colspan"] = $"{timeReseption[j, i].Duration / 30}";
                            int restOfTime = i + (timeReseption[j, i].Duration / 30);

                            if(restOfTime > countColumn && currentTable == 0)
                            {
                                timeReseption[j, limitColumn] = timeReseption[j, i];
                                timeReseption[j, limitColumn].Duration -= (restOfTime - countColumn) * 30;
                            }

                            count += timeReseption[j,i].Duration / 30;
                            tagTd.InnerHtml.AppendHtml(tagA);
                        }
                        else
                        {
                            var tagA = new TagBuilder("a");
                            tagA.MergeAttribute("href", $"/manager/reception/{i + 1}");
                            var tagDiv = new TagBuilder("div");
                            tagDiv.AddCssClass("table-td__add");
                            tagA.InnerHtml.AppendHtml(tagDiv);
                            tagTd.InnerHtml.AppendHtml(tagA);
                        }
                    }

                    tagTr.InnerHtml.AppendHtml(tagTd);
                    count += 1;
                    if (count >= limitColumn)
                    {
                        break;
                    }
                }

                tagTbody.InnerHtml.AppendHtml(tagTr);
            }
           


            tagTable.InnerHtml.AppendHtml(tagTbody);

            div.InnerHtml.AppendHtml(tagTable);
        }
    }
}
