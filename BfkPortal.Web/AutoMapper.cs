using System;
using System.Collections.Generic;

namespace BfkPortal.Web
{
    public static class AutoMapper
    {
        private static readonly IDictionary<Type, Type> Maps = new Dictionary<Type, Type>();

        public static void CreateMap<TSource, TDestination>()
        {

        }

        public static TDestination Map<TSource, TDestination>()
        {

        }

    }
}
