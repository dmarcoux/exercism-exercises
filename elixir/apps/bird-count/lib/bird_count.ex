defmodule BirdCount do
  def today([]), do: nil
  def today([daily_count | _]), do: daily_count

  def increment_day_count([]), do: [1]

  def increment_day_count([daily_count | other_daily_counts]),
    do: [daily_count + 1 | other_daily_counts]

  def has_day_without_birds?([]), do: false

  def has_day_without_birds?([daily_count | other_daily_counts]),
    do: daily_count == 0 or has_day_without_birds?(other_daily_counts)

  def total([]), do: 0
  def total([daily_count | other_daily_counts]), do: daily_count + total(other_daily_counts)

  def busy_days([]), do: 0

  def busy_days([daily_count | other_daily_counts]) when daily_count >= 5,
    do: 1 + busy_days(other_daily_counts)

  def busy_days([_daily_count | other_daily_counts]), do: busy_days(other_daily_counts)
end
