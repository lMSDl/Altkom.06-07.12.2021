namespace Models
{
    //Klasa o potencjalnie rozbudowanych kontruktorach teleskopowych
    //Właściwości mogą posłużyć do pozbycia się kontruktorów, poprzez zastąpienie ich przez inicjalizator
    //W przypadku wykorzystania konstruktora i inicjalizatora, najpierw wywołany będzie konstruktor, a pozniej inicjalizator
    public class Pizza
    {
        public Pizza()
        {
        }
        public Pizza(bool cheese, bool sauce, bool ham)
        {
            Cheese = cheese;
            Sauce = sauce;
            Ham = ham;
        }
        public Pizza(bool cheese, bool sauce, bool ham, bool tomato, bool onion)
        {
            Cheese = cheese;
            Sauce = sauce;
            Ham = ham;
            Tomato = tomato;
            Onion = onion;
        }

        public bool Cheese { get; set; }
        public bool Sauce { get; set; }
        public bool Ham { get; set; }
        public bool Tomato { get; set; }
        public bool Onion { get; set; }
    }
}
