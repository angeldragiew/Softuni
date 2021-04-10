// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		Stage stage;
		Performer performer;
		Song song;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
			performer = new Performer("Angel", "Dragiev", 20);
			song = new Song("Gamora", new TimeSpan(0,3,40));
        }


		[Test]
	    public void Performers_ReturnPerformers()
	    {
			stage.AddPerformer(performer);
			List<Performer> performers = new List<Performer>();
			performers.Add(performer);

			Assert.That(stage.Performers, Is.EquivalentTo(performers));
		}

		[Test]
		public void AddPerformerThrows_When_Null()
        {
			Assert.That(() =>
			{
				stage.AddPerformer(null);
			}, Throws.ArgumentNullException);
        }

		[Test]
		public void AddPerformerThrows_When_PerformerIsUndr18()
		{
			Assert.That(() =>
			{
				stage.AddPerformer(new Performer("a", "b", 4));
			}, Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));
		}

		[Test]
		public void AddPerformer_AddsPerformer()
        {
			stage.AddPerformer(performer);

			Assert.That(stage.Performers.Count, Is.EqualTo(1));
        }

		[Test]
		public void AddSongThrows_When_Null()
		{
			Assert.That(() =>
			{
				stage.AddSong(null);
			}, Throws.ArgumentNullException);
		}

		[Test]
		public void AddSongThrows_When_TotalMinutesLessThanOne()
		{
			Assert.That(() =>
			{
				stage.AddSong(new Song("aa", new TimeSpan(0,0,40)));
			}, Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));

			
		}


		//////////////
		///////////
		///AddSOngAdds
		//////////////////

		[Test]
		[TestCase("Angel", null)]
		[TestCase(null, "Angel")]
		[TestCase(null, null)]
		public void AddSongToPerformerThrows_When_Null(string songName, string performerName)
        {
			Assert.That(() =>
			{
				stage.AddSongToPerformer(songName, performerName);
			}, Throws.ArgumentNullException);
		}

		[Test]
		[TestCase("Angel Dragiev", "sad")]
		[TestCase("ASdd", "Gamora")]
		[TestCase("asd", "sad")]
		public void AddSongToPerformerThrows_When_PerformerOrSongDoesNotExist(string songName, string performerName)
		{
			stage.AddSong(song);
			stage.AddPerformer(performer);
			Assert.That(() =>
			{
				stage.AddSongToPerformer(songName, performerName);
			}, Throws.ArgumentException);
		}

		[Test]
		public void AddSongToPerformer_addSong()
        {
			stage.AddPerformer(performer);
			stage.AddSong(song);

			string result = stage.AddSongToPerformer("Gamora", "Angel Dragiev");

			Assert.AreEqual($"{song} will be performed by {performer}", result);
			Assert.That(performer.SongList.Contains(song), Is.True);
        }

		[Test]
		public void Play_Returns()
        {
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer("Gamora", "Angel Dragiev");

			string result = stage.Play();

			Assert.AreEqual($"{1} performers played {1} songs", result);
		}
	}
}