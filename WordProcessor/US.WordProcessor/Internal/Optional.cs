namespace US.WordProcessor.Internal
{
   internal class Optional<T>
   {
      public Optional()
      {
         HasValue = false;
      }

      public Optional(T value)
      {
         HasValue = !Equals(null, value);
         Value = value;
      }

      public readonly bool HasValue;
      public readonly T Value;

      public static implicit operator Optional<T>(T t)
      {
         return new Optional<T>(t);
      }
   }

   internal static class Optional
   {
      public static Optional<T> Of<T>(T value)
      {
         return new Optional<T>(value);
      }

      public static Optional<T> Empty<T>()
      {
         return new Optional<T>();
      }
   }
}
