﻿using System;
using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    #region Commands
    // dotnet test /p:CollectCoverage=true
    // dotnet watch test /p:CollectCoverage=true
    #endregion

    public class TestAssemblyTests
    {
        #region Setup
        Program program;

        // Constructor for setup
        public TestAssemblyTests()
        {
            this.program = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };
        }
        #endregion

        [Fact]
        public void Dexterity_has_same_SellIn_Returns_SellIn()
        {
            // Assert
            int expected = 10;

            // Act
            int actual = program.Items[0].SellIn;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sulfuras_has_same_Quality_Returns_Quality()
        {
            int expected = 80;

            int actual = program.Items[3].Quality;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SellIn_end_of_day_Returns_lower_value()
        {
            int expected = 7;

            for (int i = 0; i < 3; i++)
                program.UpdateQuality();

            int actual = program.Items[0].SellIn;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Quality_end_of_day_Returns_lower_value()
        {
            int expected = 2;

            short s = 0;
            while (s < 5)
            {
                program.UpdateQuality();
                s++;
            }

            int actual = program.Items[2].Quality;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sell_date_passed_Returns_Quality_degrades_twice_as_fast()
        {
            int expected = 1;

            for (int i = 0; i < 4; i++)
                program.UpdateQuality();

            int actual = program.Items[5].Quality;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Quality_of_item_Returns_never_negative()
        {
            for (int i = 0; i < 20; i++)
                program.UpdateQuality();

            int actual = program.Items[4].Quality;

            Assert.True(actual >= 0);
        }

        [Fact]
        public void AgidBrie_getting_older_Returns_incresing_Quality()
        {
            int expected = 1;

            program.UpdateQuality();

            int actual = program.Items[1].Quality;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Quality_of_item_Returns_never_more_than_50()
        {
            int expected = 50;

            for (int i = 0; i < 100; i++)
                program.UpdateQuality();

            int actual = program.Items[1].Quality;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sulfuras_when_sold_when_bought_Returns_same_value_always()
        {
            for (int i = 0; i < 100; i++)
                program.UpdateQuality();

            int actual = program.Items[3].Quality;

            Assert.False(actual != 80);
        }

        [Fact]
        public void BackstagePasses_when_10_days_left_Returns_increase_by_2()
        {
            int expected = 8;

            Item item = new Item {Name = "Aged Brie", SellIn = 10, Quality = 6};
            program.Items.Add(item);

            program.UpdateQuality();

            int actual = program.Items[6].Quality;

            Assert.Equal(expected, actual);
        }
    }   
}