using ShiroNet.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    public class DomainPermission : WildcardPermission
    {
        private string domain;
        private List<string> actions;
        private List<string> targets;

        public DomainPermission()
        {
            this.domain = GetDomain(GetType());
            SetParts(this.domain);
        }

        public DomainPermission(string actions)
        {
            domain = GetDomain(GetType());
            this.actions = new List<string>();
            this.actions.AddRange(actions.Split(SUBPART_DIVIDER_TOKEN));

            EncodeParts(domain, actions, null);
        }

        public DomainPermission(string actions, string targets)
        {
            this.domain = GetDomain(GetType());

            this.actions = new List<string>();
            this.actions.AddRange(actions.Split(SUBPART_DIVIDER_TOKEN));

            this.targets = new List<string>();
            this.targets.AddRange(targets.Split(SUBPART_DIVIDER_TOKEN));

            EncodeParts(this.domain, actions, targets);
        }

        protected DomainPermission(List<string> actions, List<string> targets)
        {
            this.domain = GetDomain(GetType());
            SetParts(domain, actions, targets);
        }

        private void EncodeParts(string domain, string actions, string targets)
        {
            if (!StringUtils.HasText(domain))
            {
                throw new ArgumentException("domain argument cannot be null or empty.");
            }
            StringBuilder sb = new StringBuilder(domain);

            if (!StringUtils.HasText(actions))
            {
                if (StringUtils.HasText(targets))
                {
                    sb.Append(PART_DIVIDER_TOKEN).Append(WILDCARD_TOKEN);
                }
            }
            else
            {
                sb.Append(PART_DIVIDER_TOKEN).Append(actions);
            }
            if (StringUtils.HasText(targets))
            {
                sb.Append(PART_DIVIDER_TOKEN).Append(targets);
            }
            SetParts(sb.ToString());
        }

        protected void SetParts(string domain, List<string> actions, List<string> targets)
        {
            string actionsString = string.Join(SUBPART_DIVIDER_TOKEN, actions);
            string targetsString = string.Join(SUBPART_DIVIDER_TOKEN, targets);

            EncodeParts(domain, actionsString, targetsString);

            this.domain = domain;
            this.actions = actions;
            this.targets = targets;
        }

        protected string GetDomain(Type clazz)
        {
            string domain = clazz.Name.ToLower();
            //strip any trailing 'permission' text from the name (as all subclasses should have been named):
            int index = domain.LastIndexOf("permission");
            if (index != -1)
            {
                domain = domain.Substring(0, index);
            }
            return domain;
        }

        public String GetDomain()
        {
            return domain;
        }

        protected void SetDomain(String domain)
        {
            if (this.domain != null && this.domain.Equals(domain))
            {
                return;
            }
            this.domain = domain;
            SetParts(domain, actions, targets);
        }

        public List<string> GetActions()
        {
            return actions;
        }

        protected void SetActions(List<string> actions)
        {
            if (this.actions != null && this.actions.Equals(actions))
            {
                return;
            }
            this.actions = actions;
            SetParts(domain, actions, targets);
        }

        public List<string> getTargets()
        {
            return targets;
        }

        protected void setTargets(List<string> targets)
        {
            if (this.targets != null && this.targets.Equals(targets))
            {
                return;
            }
            this.targets = targets;
            SetParts(domain, actions, targets);
        }
    }
}
