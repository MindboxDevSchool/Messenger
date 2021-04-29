using System;
using System.Collections.Generic;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public static class Repr<T>
    {
        private static readonly Dictionary<Type, (Func<string, T>, Func<T, string>)> TypeMap =
            new Dictionary<Type, (Func<string, T> parser, Func<T, string> renderer)>()
            {
                { typeof(Message), (
                    s => (T)(object) Message.Parse(s),
                    o => Message.Render((Message)(object) o)
                )},
                { typeof(Member), (
                    s => (T)(object) Member.Parse(s),
                    o => Member.Render((Member)(object) o)
                )},
                { typeof(Chat), (
                    s => (T)(object) Chat.Parse(s),
                    o => Chat.Render((Chat)(object) o)
                )},
                { typeof(User), (
                    s => (T)(object) User.Parse(s),
                    o => User.Render((User)(object) o)
                )},
                { typeof(Session), (
                    s => (T)(object) Session.Parse(s),
                    o => Session.Render((Session)(object) o)
                )},
            };
        
        public static Maybe<T> Parse(string representation)
        {
            foreach (Type type in TypeMap.Keys)
                if (typeof(T).IsAssignableFrom(type))
                    return new Maybe<T>.Some(TypeMap[type].Item1.Invoke(representation));

            throw new NotSupportedException();
        }
        public static string Render(T obj)
        {
            foreach (Type type in TypeMap.Keys)
                if (typeof(T).IsAssignableFrom(type))
                    return TypeMap[type].Item2.Invoke(obj);

            throw new NotSupportedException();
        }
    }
}
