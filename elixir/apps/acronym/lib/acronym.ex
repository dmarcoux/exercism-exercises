defmodule Acronym do
  @doc """
  Generate an acronym from a string.
  "This is a string" => "TIAS"
  """
  @spec abbreviate(String.t()) :: String.t()
  def abbreviate(string) do
    string
    # Remove every punctuation, except hyphen which is a word separator
    |> String.replace(~r/[^\P{P}-]+/, "")
    # Split on hyphen and space
    |> String.split(~r{-| }, trim: true)
    # Capitalize the first letter of every word, then join those letters to form an acronym
    |> Enum.map_join(fn word ->
      word
      |> String.first()
      |> String.upcase()
    end)
  end
end
