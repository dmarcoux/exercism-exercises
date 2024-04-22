defmodule HighSchoolSweetheart do
  def first_letter(name) when is_binary(name), do: name |> String.trim() |> String.first()

  def initial(name) when is_binary(name),
    do: name |> first_letter() |> String.upcase() |> Kernel.<>(".")

  def initials(full_name) when is_binary(full_name),
    do: full_name |> String.split() |> Enum.map_join(" ", &initial/1)

  def pair(full_name1, full_name2) do
    """
         ******       ******
       **      **   **      **
     **         ** **         **
    **            *            **
    **                         **
    **     #{initials(full_name1)}  +  #{initials(full_name2)}     **
     **                       **
       **                   **
         **               **
           **           **
             **       **
               **   **
                 ***
                  *
    """
  end
end
