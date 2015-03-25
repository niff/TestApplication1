﻿using System;
using System.Linq;
using System.Text;
using System.Web;
using IglaClub.ObjectModel.Enums;

namespace IglaClub.Web.Helpers.Html
{
    public static class TournamentHelper
    {
        public static IHtmlString GetSubscribtionStatus(bool subscribed, long id)
        {
            if (subscribed)
            {
                return new HtmlString(@"<span class='glyphicon glyphicon-ok-circle' 
                        title='You are subscribed to this tournament'></span>
                        <span>Joined</span>");
            }
            return
                new HtmlString(string.Format(@"<a href='details/{0}'><i class='glyphicon glyphicon-plus'></i>Join</a>",
                                             id));
        }

        public static IHtmlString GetTournamentStatusIcon(TournamentStatus status)
        {
            bool isStarted = status == TournamentStatus.Started;
            bool isPlanned = status == TournamentStatus.Planned;
            var statusLabelClass = isPlanned ? "planned" : (isStarted ? "ongoing" : "past");
            var statusLabel = isPlanned ? "not started" : (isStarted ? "started" : "finished");

            var statusIcon = string.Format("<span class='tournament-status {0}'>{1}</span>", statusLabelClass,
                                           statusLabel);
            return new HtmlString(statusIcon);
        }

        public static IHtmlString ContractColorsDropDown(string ddId, ContractColors selected)
        {
            const string imgPath = "../../Content/img/cards/";
            var dropdown = new StringBuilder();

            dropdown.Append(string.Format("<select id=\"{0}\">", ddId));

            foreach (var color in Enum.GetValues(typeof(ContractColors)).Cast<ContractColors>())
            {
                dropdown.Append(
                    string.Format(
                        "<option value=\"{0}\" data-imagesrc=\"{1}{2}.png\" {3} data-description=\"\"></option>",
                        ((int) color).ToString(), imgPath, color.ToString().ToLowerInvariant(),
                        color == selected ? "selected=\"selected\"" : string.Empty));
            }

            dropdown.Append("</select>");

            return new HtmlString(dropdown.ToString());
        }
    }
}