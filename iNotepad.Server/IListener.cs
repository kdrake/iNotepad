using AutocompleteClassLibrary;

namespace iNotepad.Server
{
    public interface IListener
    {
        void Listen(IAutocompleteService autocompele);
    }
}