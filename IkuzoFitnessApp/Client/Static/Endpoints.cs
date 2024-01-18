namespace IkuzoFitnessApp.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string CustomerRoutinesEndpoint = $"{Prefix}/customerRoutines";
        public static readonly string ExercisesEndpoint = $"{Prefix}/exercises";
        public static readonly string GoalsEndpoint = $"{Prefix}/goals";
        public static readonly string PaymentsEndpoint = $"{Prefix}/payments";
        public static readonly string ProgressTracksEndpoint = $"{Prefix}/progrssTracks";
        public static readonly string RoutinesEndpoint = $"{Prefix}/routines";
        public static readonly string SubscriptionsEndpoint = $"{Prefix}/subscriptions";
        public static readonly string WorkoutsEndpoint = $"{Prefix}/workouts";
    }
}
