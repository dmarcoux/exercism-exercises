defmodule Username do
  def sanitize(''), do: ''

  def sanitize([character | characters]) do
    case character do
      character when character in ?a..?z -> [character]
      ?_ -> '_'
      ?ä -> 'ae'
      ?ö -> 'oe'
      ?ü -> 'ue'
      ?ß -> 'ss'
      _ -> ''
    end ++ sanitize(characters)
  end
end
