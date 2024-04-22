defmodule BasketballWebsite do
  def extract_from_path(data, path) do
    paths = String.split(path, ".")

    extract(data, paths)
  end

  def get_in_path(data, path) do
    paths = String.split(path, ".")

    Kernel.get_in(data, paths)
  end

  defp extract(data, [path]), do: data[path]
  defp extract(data, [path | other_paths]), do: extract(data[path], other_paths)
end
