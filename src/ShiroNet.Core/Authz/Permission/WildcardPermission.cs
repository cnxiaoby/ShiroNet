using ShiroNet.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    [Serializable]
    public class WildcardPermission : IPermission
    {
        protected const string WILDCARD_TOKEN = "*";
        protected const string PART_DIVIDER_TOKEN = ":";
        protected const char SUBPART_DIVIDER_TOKEN = ',';
        protected const bool DEFAULT_CASE_SENSITIVE = false;

        private List<List<string>> parts;

        protected WildcardPermission()
        {
        }

        public WildcardPermission(string wildcardString)
        {
            SetParts(wildcardString, DEFAULT_CASE_SENSITIVE);
        }

        public WildcardPermission(string wildcardString, bool caseSensitive)
        {
            SetParts(wildcardString, caseSensitive);
        }

        protected void SetParts(string wildcardString)
        {
            SetParts(wildcardString, DEFAULT_CASE_SENSITIVE);
        }

        protected void SetParts(string wildcardString, bool caseSensitive)
        {
            wildcardString = StringUtils.Clean(wildcardString);

            if (string.IsNullOrEmpty(wildcardString))
            {
                throw new ArgumentException("Wildcard string cannot be null or empty. Make sure permission strings are properly formatted.");
            }

            if (!caseSensitive)
            {
                wildcardString = wildcardString.ToLower();
            }

            List<string> parts = new List<string>();
            parts.AddRange(wildcardString.Split(PART_DIVIDER_TOKEN));

            this.parts = new List<List<string>>();
            foreach (string part in parts)
            {
                if (string.IsNullOrEmpty(part))
                {
                    throw new ArgumentException("Wildcard string cannot contain parts with only dividers. Make sure permission strings are properly formatted.");
                }

                List<string> subparts = new List<string>();
                subparts.AddRange(part.Split(SUBPART_DIVIDER_TOKEN));
                
                this.parts.Add(subparts);
            }

            if (this.parts.Count == 0)
            {
                throw new ArgumentException("Wildcard string cannot contain only dividers. Make sure permission strings are properly formatted.");
            }
        }

        protected List<List<string>> GetParts()
        {
            return this.parts;
        }

        protected void SetParts(List<List<string>> parts)
        {
            this.parts = parts;
        }

        public bool Implies(IPermission permission)
        {
            // By default only supports comparisons with other WildcardPermissions
            if (!(permission is WildcardPermission)) {
                return false;
            }

            WildcardPermission wp = (WildcardPermission)permission;

            List<List<string>> otherParts = wp.GetParts();

            int i = 0;
            foreach (List<string> otherPart in otherParts)
            {
                // If this permission has less parts than the other permission, everything after the number of parts contained
                // in this permission is automatically implied, so return true
                if (GetParts().Count - 1 < i)
                {
                    return true;
                }
                else
                {
                    List<string> part = GetParts()[i];
                    if (!part.Contains(WILDCARD_TOKEN) && !ContainsAll(part, otherPart))
                    {
                        return false;
                    }
                    i++;
                }
            }

            // If this permission has more parts than the other parts, only imply it if all of the other parts are wildcards
            for (; i < GetParts().Count; i++)
            {
                List<string> part = GetParts()[i];
                if (!part.Contains(WILDCARD_TOKEN))
                {
                    return false;
                }
            }

            return true;
        }

        bool ContainsAll(List<string> src, List<string> contains)
        {
            foreach(var s in contains)
            {
                if (!src.Contains(s))
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            foreach (List<string> part in this.parts)
            {
                if (buffer.Length > 0)
                {
                    buffer.Append(PART_DIVIDER_TOKEN);
                }

                StringBuilder pasb = new StringBuilder();
                foreach (var pa in part)
                {
                    if (pasb.Length > 0)
                    {
                        pasb.Append(SUBPART_DIVIDER_TOKEN);
                    }
                    pasb.Append(pa);
                }

                buffer.Append(pasb.ToString());
            }
            return buffer.ToString();
        }

        public override bool Equals(object o)
        {
            if (o is WildcardPermission wp)
            {
                return parts.Equals(wp.parts);
            }
            return false;
        }

        public int HashCode()
        {
            return parts.GetHashCode();
        }

        public override int GetHashCode()
        {
            return parts.GetHashCode();
        }
    }
}
