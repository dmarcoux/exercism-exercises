defmodule Chessboard do
  @spec rank_range() :: Range.t()
  def rank_range, do: 1..8

  @spec file_range() :: Range.t()
  def file_range, do: ?A..?H

  @spec ranks() :: list(pos_integer())
  def ranks, do: Enum.to_list(rank_range())

  @spec files() :: list(String.t())
  def files, do: Enum.map(file_range(), &<<&1::utf8>>)
end
