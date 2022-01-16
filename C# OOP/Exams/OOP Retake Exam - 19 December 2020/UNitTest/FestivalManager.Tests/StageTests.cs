// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using System.Linq;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        private Stage stage;
        [SetUp]
        public void Setup()
        { 
            stage = new Stage();
        }

		[Test]
	    public void AddPerformer_ThrowExeptionForNullPerformer()
        {
            Performer performer = null;

            Assert.Throws<ArgumentNullException>((() => stage.AddPerformer(performer)));
        }

        [Test]
        public void AddPerformer_ThrowExceptionForPerformerAge()
        {
            Performer performer = new Performer("Gosho", "Ivanov",15);
            Assert.Throws<ArgumentException>((() => stage.AddPerformer(performer)));
        }

        [Test]
        public void AddPerformer_AddSuccessfully()
        {
            Performer performer = new Performer("Gosho", "Ivanov", 25);
            stage.AddPerformer(performer);
            Assert.AreEqual(stage.Performers.Count, 1);
        }

        [Test]
        public void AddSong_ThrowNullException()
        {
            Song song = null;
            Assert.Throws<ArgumentNullException>((() => stage.AddSong(song)));
        }

        [Test]
        public void AddSong_ThrowException()
        {
            Song song = new Song("Galin", new TimeSpan(-1));
            Assert.Throws<ArgumentException>((() => stage.AddSong(song)));
        }

        [Test]
        public void AddSongToPerformer_ThrowNullExceptions()
        {
            Performer performer = null;
            Song song = null;

            Assert.Throws<ArgumentNullException>((() => stage.AddPerformer(performer)));
            Assert.Throws<ArgumentNullException>((() => stage.AddSong(song)));
        }

        [Test]
        public void AddSongToPerformer_ReturnRightOutput()
        {
            Performer performer = new Performer("Gosho", "Ivanov", 25);
            Song song = new Song("Galin", new TimeSpan(600000052));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.AreEqual(stage.AddSongToPerformer(song.Name, performer.FullName), $"{song} will be performed by {performer}");
            Assert.AreEqual(1,performer.SongList.Count);
        }

        [Test]
        public void Play_ReturnRightOutput()
        {
            Performer performer = new Performer("Gosho", "Ivanov", 25);
            Song song = new Song("Galin", new TimeSpan(600000052));
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            var songsCount = this.stage.Performers.Sum(p => p.SongList.Count());
            Assert.AreEqual(stage.Play(), $"{stage.Performers.Count} performers played {songsCount} songs");
        }
        

    }
}