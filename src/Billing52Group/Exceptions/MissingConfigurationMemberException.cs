using System;

namespace Billing52Group.Exceptions
{
    public class MissingConfigurationMemberException : Exception
    {
        const string _guide = "Create appsettings.json file in project root with assigned missing member and try again.";

        public MissingConfigurationMemberException(string memberPath) : base(
            $"Missing required member {memberPath.Replace(':', '.')}. {_guide}")
        {
        }
    }
}
